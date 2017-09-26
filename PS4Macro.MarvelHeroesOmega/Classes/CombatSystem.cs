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
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PS4Macro.MarvelHeroesOmega
{
    // Holds information of the found enemy
    public class EnemyInfo
    {
        public int Health { get; set; }

        public EnemyInfo()
        {
            Health = -1;
        }
    }

    public class CombatSystem
    {
        #region Statics
        public static int FilteredHealthColor = 0xE14B4B;
        public static int GreenBarColor = 0x4BE14B;

        public static int GreenBarScanHeight = 19;

        // Enemy name crop rectangle
        public static Rectangle R_EnemyNameArea = new Rectangle()
        {
            X = 421,
            Y = 114,
            Width = 167,
            Height = 27
        };

        // Enemy health crop rectangle (offset from cropped EnemyNameArea)
        public static Rectangle R_EnemyHealth = new Rectangle()
        {
            X = 4,
            Y = 11,
            Width = 155,
            Height = 7
        };

        // Start of green color bar (offset from cropped EnemyNameArea)
        public static Point P_ColorBarStart = new Point()
        {
            X = 164,
            Y = 3
        };

        // To check for full health (offset from cropped EnemyNameArea)
        public static PixelMap P_EnemyHealthFull = new PixelMap()
        {
            X = 158,
            Y = 13,
            Color = FilteredHealthColor
        };
        #endregion

        public bool TargetLocked { get; private set; }
        public DateTime LastTargetLockedTime { get; private set; }
        public DateTime LastFoundEnemyTime { get; private set; }
        public int LastEnemyHealth { get; private set; }
        public List<int> EnemyHealthHistory { get; private set; }

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
                
                // Enemy health is full
                if (filteredBmp.GetPixel(P_EnemyHealthFull.X, P_EnemyHealthFull.Y) == targetHealthColor)
                {
                    enemyInfo.Health = 100;
                }
                // Enemy health not full
                else
                {
                    var width = R_EnemyHealth.Width;
                    // Dots needed to count
                    var dotsNeeded = 3;

                    // Scan enemy health bar from right to left
                    for (var i = width - 1; i > 0; i--)
                    {
                        int foundRedCount = 0;
                        bool breakOuter = false;
                        for (var j = 11; j <= 17; j++)
                        {
                            // Found red
                            var checkRedColor = filteredBmp.GetPixel(i, j);
                            if (checkRedColor == targetHealthColor)
                            {
                                foundRedCount++;
                            }

                            // Enough red dots are found
                            if (foundRedCount >= dotsNeeded)
                            {
                                breakOuter = true;
                                enemyInfo.Health = (int)((i / Convert.ToDouble(width)) * 100);
                                break;
                            }
                        }

                        // Exit if we found the value
                        if (breakOuter)
                            break;
                    }
                }

                return enemyInfo;
            }

            return null;
        }

        private void Walk(Script script, int direction, int delay)
        {
            switch (direction)
            {
                case PlayerMovement.TOP:
                    script.Press(new DualShockState() { LY = (byte)0 }, delay);
                    break;

                case PlayerMovement.RIGHT:
                    script.Press(new DualShockState() { LX = (byte)255 }, delay);
                    break;

                case PlayerMovement.BOTTOM:
                    script.Press(new DualShockState() { LY = (byte)255 }, delay);
                    break;

                case PlayerMovement.LEFT:
                    script.Press(new DualShockState() { LX = (byte)0 }, delay);
                    break;
            }
        }

        private void RoamMap(Script script)
        {
            var analogDirection = Helper.DegreesToAnalog(script.WalkDirection);
            //script.Press(new DualShockState() { LX = (byte)analogDirection.X, LY = (byte)analogDirection.Y });

            //script.Press(new DualShockState() { LX = (byte)analogDirection.X, LY = (byte)analogDirection.Y }, (int)(script.WalkDistance + 1) * 100);

            var multiplier = 50;
            Walk(script, (int)script.WalkDirection, (int)(script.WalkDistance + 1) * multiplier);
        }

        private void ResetEnemyData()
        {
            // Clear target lock flag
            TargetLocked = false;
            // Reset enemy health history
            EnemyHealthHistory = null;
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
                Debug.WriteLine("ENEMY HEALTH: {0}", enemy.Health);

                LastFoundEnemyTime = DateTime.Now;
                LastEnemyHealth = enemy.Health;

                // Lazy initialize enemy health
                if (EnemyHealthHistory == null)
                    EnemyHealthHistory = new List<int>();

                // Add enemy health to history
                EnemyHealthHistory.Add(LastEnemyHealth);

                // Lock target
                if (!TargetLocked)
                {
                    script.Press(new DualShockState() { R1 = true });
                    TargetLocked = true;
                    LastTargetLockedTime = DateTime.Now;

                    // Teleport
                    // TODO: Make button changable
                    script.Press(new DualShockState() { Circle = true });
                }

                // Attack
                script.Press(new DualShockState() { Cross = true });

                // Check enemy health for progress
                var enemyHealthLimit = 5;
                if (EnemyHealthHistory.Count >= enemyHealthLimit)
                {
                    // Search through history
                    bool shouldReset = true;
                    foreach (var h in EnemyHealthHistory)
                    {
                        if (h != EnemyHealthHistory.First())
                        {
                            // Reset enemy health history
                            EnemyHealthHistory = null;
                            // But don't reset state
                            shouldReset = false;
                            break;
                        }
                    }

                    // Reset if enemy does not take any damage for a while
                    if (shouldReset)
                    {
                        // Unlock target
                        script.Press(new DualShockState() { R1 = true });
                        TargetLocked = false;

                        // Reset
                        ResetEnemyData();

                        // Walk random direction for a second
                        Random rnd = new Random();
                        var directions = new int[] { PlayerMovement.TOP, PlayerMovement.RIGHT, PlayerMovement.BOTTOM, PlayerMovement.LEFT };
                        Walk(script, directions[rnd.Next(directions.Length)], 1000);
                    }
                }
            }
            // Enemy not found
            else
            {
                // Reset
                ResetEnemyData();

                // Roam the map
                if (script.WalkDirection != -1)
                {
                    RoamMap(script);
                }
            }
        }
    }
}
