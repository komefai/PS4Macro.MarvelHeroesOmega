// PS4Macro.MarvelHeroesOmega (File: Classes/EnemyRadar.cs)
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

    public class EnemyRadar
    {
        public static int FilteredHealthColor = 0xE14B4B;
        public static int GreenBarColor = 0x4BE14B;

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

        public EnemyInfo DetectEnemy(Script script)
        {
            // Crop
            var bmp = script.CropFrame(R_EnemyNameArea);
            // Apply filter
            Bitmap greenBarBmp = Helper.PosterizeFilter(bmp);

            Color targetGreenBarColor = GreenBarColor.ToColorOpaque();
            Color targetHealthColor = FilteredHealthColor.ToColorOpaque();

            bool foundGreenBar = true;
            for (var i = 0; i < 19; i++)
            {
                //Debug.WriteLine(newBmp.GetPixel(163, 2 + i));

                // Check if all is green
                if (greenBarBmp.GetPixel(P_ColorBarStart.X, P_ColorBarStart.Y + i) != targetGreenBarColor)
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
    }
}
