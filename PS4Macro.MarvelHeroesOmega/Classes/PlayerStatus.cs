// PS4Macro.MarvelHeroesOmega (File: Classes/PlayerStatus.cs)
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

using AForge.Imaging.Filters;
using PS4MacroAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PS4Macro.MarvelHeroesOmega
{
    public class PlayerStatus
    {
        #region Health
        public static int FilteredHealthColor = 0xE14B4B;

        // Health bar crop rectangle
        public static Rectangle R_HealthBar = new Rectangle()
        {
            X = 184,
            Y = 578,
            Width = 228,
            Height = 13
        };

        // To check for full health (offset from cropped)
        public static PixelMap P_HealthFull = new PixelMap()
        {
            X = 225,
            Y = 1,
            Color = 0xE14B4B
        };

        public int lastKnownHealth = -1;
        public int DetectHealth(Script script)
        {
            // Crop
            var bmp = script.CropFrame(R_HealthBar);
            // Apply filter
            Bitmap filteredBmp = Helper.PosterizeFilter(bmp);

            int healthPercent = -1;
            Color targetHealthColor = FilteredHealthColor.ToColorOpaque();

            // Health is full
            if (filteredBmp.GetPixel(P_HealthFull.X, P_HealthFull.Y) == targetHealthColor)
            {
                healthPercent = 100;
            }
            // Health is not full
            else
            {
                // Width of health bar
                var width = P_HealthFull.X;
                // Dots needed to count
                var dotsNeeded = 3;

                // Scan health bar from right to left
                for (var i = width - 1; i > 0; i--)
                {
                    // Skip health icon area
                    if (i == 221 || i == 220 || i == 219)
                        continue;

                    int foundRedCount = 0;
                    bool breakOuter = false;
                    for (var j = 2; j <= 10; j++)
                    {
                        // Found red
                        if (filteredBmp.GetPixel(i, j) == targetHealthColor)
                        {
                            foundRedCount++;
                        }

                        // Enough red dots are found
                        if (foundRedCount >= dotsNeeded)
                        {
                            breakOuter = true;
                            healthPercent = (int)((i / Convert.ToDouble(width)) * 100);
                            break;
                        }
                    }

                    // Exit if we found the value
                    if (breakOuter)
                        break;
                }
            }

            // Use last known value if invalid
            if (healthPercent != -1)
                lastKnownHealth = healthPercent;

            return lastKnownHealth;
        }
        #endregion

        #region Spirit
        public static int FilteredSpiritColor_1 = 0x4B4BE1;
        public static int FilteredSpiritColor_2 = 0x4BE1E1;

        // Spirit bar crop rectangle
        public static Rectangle R_SpiritBar = new Rectangle()
        {
            X = 205,
            Y = 566,
            Width = 115,
            Height = 8
        };

        // To check for full spirit (offset from cropped)
        public static Point P_SpiritFull = new Point()
        {
            X = 114,
            Y = 3
        };

        public int lastKnownSpirit = -1;
        public int DetectSpirit(Script script)
        {
            // Crop
            var bmp = script.CropFrame(R_SpiritBar);
            // Apply filter
            Bitmap filteredBmp = Helper.PosterizeFilter(bmp);

            int spiritPercent = -1;
            Color targetSpiritColor_1 = FilteredSpiritColor_1.ToColorOpaque();
            Color targetSpiritColor_2 = FilteredSpiritColor_2.ToColorOpaque();

            // Spirit is full
            var checkFullColor = filteredBmp.GetPixel(P_SpiritFull.X, P_SpiritFull.Y);
            if (checkFullColor == targetSpiritColor_1 || checkFullColor == targetSpiritColor_2)
            {
                spiritPercent = 100;
            }
            // Spirit is not full
            else
            {
                // Width of spirit bar
                var width = P_SpiritFull.X;
                // Dots needed to count
                var dotsNeeded = 3;

                // Scan spirit bar from right to left
                for (var i = width - 1; i > 0; i--)
                {
                    int foundBlueCount = 0;
                    bool breakOuter = false;
                    for (var j = 1; j <= 7; j++)
                    {
                        // Found blue
                        var checkBlueColor = filteredBmp.GetPixel(i, j);
                        if (checkBlueColor == targetSpiritColor_1 || checkBlueColor == targetSpiritColor_2)
                        {
                            foundBlueCount++;
                        }

                        // Enough blue dots are found
                        if (foundBlueCount >= dotsNeeded)
                        {
                            breakOuter = true;
                            spiritPercent = (int)((i / Convert.ToDouble(width)) * 100);
                            break;
                        }
                    }

                    // Exit if we found the value
                    if (breakOuter)
                        break;
                }
            }

            // Use last known value if invalid
            if (spiritPercent != -1)
                lastKnownSpirit = spiritPercent;

            return lastKnownSpirit;
        }
        #endregion
    }
}
