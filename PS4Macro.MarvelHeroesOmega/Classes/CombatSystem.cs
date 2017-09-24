// PS4Macro.MarvelHeroesOmega (File: Classes/CombatSystem.cs)
//
// Copyright (c) 2017 Komefai
//
// Visit http://komefai.com for more information
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using PS4MacroAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PS4Macro.MarvelHeroesOmega
{
    // Holds information of the found enemy
    public class EnemyInfo
    {
        public int Health { get; set; }
    }

    public class CombatSystem
    {
        #region Statics
        public static int FilteredHealthColor = 0xE14B4B;
        public static int GreenBarColor = 0x4BE14B;

        public static int GreenBarScanHeight = 19;

        public static Rectangle R_EnemyNameArea = new Rectangle()
        {
            X = 421,
            Y = 114,
            Width = 167,
            Height = 27
        };

        public static Point P_ColorBarStart = new Point()
        {
            X = 164,
            Y = 3
        };
        #endregion

        public bool TargetLocked { get; private set; }
        public DateTime LastTargetLockedTime { get; private set; }
        public DateTime LastFoundEnemyTime { get; private set; }

        public EnemyInfo DetectEnemy(Script script)
        {
            // Crop
            var bmp = script.CropFrame(R_EnemyNameArea);
            // Apply filter
            Bitmap filteredBmp = Helper.PosterizeFilter(bmp);

            Color targetGreenBarColor = GreenBarColor.ToColorOpaque();
            Color targetHealthColor = FilteredHealthColor.ToColorOpaque();

            bool foundGreenBar = true;
            for (var i = 0; i < GreenBarScanHeight; i++)
            {
                //Debug.WriteLine(newBmp.GetPixel(163, 2 + i));

                // Check if all is green
                if (filteredBmp.GetPixel(P_ColorBarStart.X, P_ColorBarStart.Y + i) != targetGreenBarColor)
                {
                    foundGreenBar = false;
                    break;
                }
            }

            if (foundGreenBar)
            {
                var enemyInfo = new EnemyInfo();
                
                // TODO: Read enemy health

                return enemyInfo;
            }

            return null;
        }

        public void Update(Script script)
        {
            // Use med kit
            if (script.HealthPercent <= script.MainForm.GetUseMedKidBelowValue())
            {
                script.Press(new DualShockState() { L1 = true });
            }

            // Detect enemy
            EnemyInfo enemy = DetectEnemy(script);

            // Found enemy
            if (enemy != null)
            {
                LastFoundEnemyTime = DateTime.Now;

                // Lock target
                if (!TargetLocked)
                {
                    script.Press(new DualShockState() { R1 = true });
                    TargetLocked = true;
                    LastTargetLockedTime = DateTime.Now;

                    // Teleport
                    script.Press(new DualShockState() { Circle = true });
                }

                // Attack
                script.Press(new DualShockState() { Cross = true });
            }
            // Enemy not found
            else
            {
                TargetLocked = false;

                if (script.WalkDirection != -1)
                {
                    var analogDirection = Helper.DegreesToAnalog(script.WalkDirection);
                    //script.Press(new DualShockState() { LX = (byte)analogDirection.X, LY = (byte)analogDirection.Y });

                    //script.Press(new DualShockState() { LX = (byte)analogDirection.X, LY = (byte)analogDirection.Y }, (int)(script.WalkDistance + 1) * 100);

                    var multiplier = 50;
                    switch ((int)script.WalkDirection)
                    {
                        case PlayerMovement.TOP:
                            script.Press(new DualShockState() { LY = (byte)0 }, (int)(script.WalkDistance + 1) * multiplier);
                            break;

                        case PlayerMovement.RIGHT:
                            script.Press(new DualShockState() { LX = (byte)255 }, (int)(script.WalkDistance + 1) * multiplier);
                            break;

                        case PlayerMovement.BOTTOM:
                            script.Press(new DualShockState() { LY = (byte)255}, (int)(script.WalkDistance + 1) * multiplier);
                            break;

                        case PlayerMovement.LEFT:
                            script.Press(new DualShockState() { LX = (byte)0 }, (int)(script.WalkDistance + 1) * multiplier);
                            break;
                    }
                }
            }
        }
    }
}
