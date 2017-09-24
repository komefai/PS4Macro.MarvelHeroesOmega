// PS4Macro.MarvelHeroesOmega (File: Classes/PlayerMovement.cs)
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
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PS4Macro.MarvelHeroesOmega
{
    public class PlayerMovement
    {
        public const int TOP = 0;
        public const int RIGHT = 90;
        public const int BOTTOM = 180;
        public const int LEFT = 270;

        #region Rotation
        public static int FilteredCircleColor_1 = 0x4B4BE1;
        public static int FilteredCircleColor_2 = 0x4BE1E1;

        public static int RadiusOffset = 9;
        public static int HorizontalRadius = 40 + RadiusOffset;
        public static int VerticalRadius = 23 + RadiusOffset;

        // Player circle crop rectangle
        public static Rectangle R_PlayerCircle = new Rectangle()
        {
            X = 454,
            Y = 266,
            Width = 100,
            Height = 100
        };

        // Center to player circle
        public static Point P_PlayerCenter = new Point()
        {
            X = 504,
            Y = 319
        };

        // Center to player circle (offset to crop)
        public static Point P_PlayerCenterOffset = new Point()
        {
            X = 50,
            Y = 53
        };

        public static Point ConvertPlayerRotation(double degrees)
        {
            //double radians = Helper.DegreesToRadians(degrees);

            //// x = a.cos(θ), y = b.sin(θ)
            //double a = HorizontalRadius;
            //double b = VerticalRadius;

            //int x = (int)Math.Round((Math.Cos(radians) * a) + P_PlayerCenterOffset.X);
            //int y = (int)Math.Round((Math.Sin(radians) * b) + P_PlayerCenterOffset.Y);

            //return new Point(x, y);

            return Helper.EllipseDegreesToPoint(HorizontalRadius, VerticalRadius, degrees, P_PlayerCenterOffset.X, P_PlayerCenterOffset.Y);
        }

        public double DetectRotation(Script script)
        {
            // Crop
            var bmp = script.CropFrame(R_PlayerCircle);
            // Apply filter
            Bitmap filteredBmp = Helper.PosterizeFilter(bmp);

            Color targetCircleColor_1 = FilteredCircleColor_1.ToColorOpaque();
            Color targetCircleColor_2 = FilteredCircleColor_2.ToColorOpaque();

            // Scan the whole circle
            for (var degrees = 0; degrees < 360; degrees++)
            {
                // Rotate the degrees so that 0 faces north
                var rotated = degrees - 90;
                if (rotated < 0) rotated = 360 - rotated;

                // Check at degree
                Point p = ConvertPlayerRotation(rotated);
                var checkBlueColor = filteredBmp.GetPixel(p.X, p.Y);

                // Check at degrees + 1
                Point p1 = ConvertPlayerRotation(rotated + 1);
                var checkNextBlueColor = filteredBmp.GetPixel(p1.X, p1.Y);

                bool checkColor = checkBlueColor == targetCircleColor_1 || checkBlueColor == targetCircleColor_2;
                bool checkNextColor = checkNextBlueColor == targetCircleColor_1 || checkNextBlueColor == targetCircleColor_2;

                // Color is matched
                if (checkColor && checkNextColor)
                {
                    Debug.WriteLine("DEGREES ({0}, {1}): {2}", p.X, p.Y, degrees);
                    return degrees;
                }
            }

            return -1;
        }
        #endregion

        #region Minimap
        public static int FilteredWalkableColor = 0x000000;

        // Offset to start searching
        public static int PlayerOriginOffset = 6;

        // Minimap crop rectangle
        public static Rectangle R_Minimap = new Rectangle()
        {
            X = 842,
            Y = 139,
            Width = 93,
            Height = 69
        };

        // Origin point of player in minimap
        public static Point P_PlayerOrigin = new Point()
        {
            X = 46,
            Y = 33
        };

        private int m_LastWalkDirection = -1;
        private int m_LastWalkDistance = -1;

        private int ScanAreaFromOrigin(Bitmap filteredBmp, int direction)
        {
            int value = 0;

            Color targetWalkableColor = FilteredWalkableColor.ToColorOpaque();

            // TODO: Refactor
            try
            {
                while (value <= 10000)
                {
                    Color foundColor = Color.White;

                    if (direction == TOP)
                    {
                        foundColor = filteredBmp.GetPixel(P_PlayerOrigin.X, P_PlayerOrigin.Y - value - PlayerOriginOffset);
                    }
                    else if (direction == RIGHT)
                    {
                        foundColor = filteredBmp.GetPixel(P_PlayerOrigin.X + value + PlayerOriginOffset, P_PlayerOrigin.Y);
                    }
                    else if (direction == BOTTOM)
                    {
                        foundColor = filteredBmp.GetPixel(P_PlayerOrigin.X, P_PlayerOrigin.Y + value + PlayerOriginOffset);
                    }
                    else if (direction == LEFT)
                    {
                        foundColor = filteredBmp.GetPixel(P_PlayerOrigin.X - value - PlayerOriginOffset, P_PlayerOrigin.Y);
                    }
                    else
                    {
                        break;
                    }

                    if (foundColor != targetWalkableColor)
                    {
                        return value;
                    }

                    value++;
                }
            }
            catch (ArgumentOutOfRangeException) { }

            return -1;
        }

        public int GetOppositeDirection(int direction)
        {
            switch(direction)
            {
                case TOP: return BOTTOM;
                case BOTTOM: return TOP;
                case LEFT: return RIGHT;
                case RIGHT: return LEFT;
                default: return -1;
            }
        }

        public KeyValuePair<int, int> FindWalkDirection(Script script)
        {
            // Crop
            var bmp = script.CropFrame(R_Minimap);
            // Apply filter
            Bitmap filteredBmp = Helper.SobelEdgeFilter(bmp);

            // Scan distances in each direction
            var distances = new Dictionary<int, int>();
            distances.Add(TOP, ScanAreaFromOrigin(filteredBmp, TOP));
            distances.Add(RIGHT, ScanAreaFromOrigin(filteredBmp, RIGHT));
            distances.Add(BOTTOM, ScanAreaFromOrigin(filteredBmp, BOTTOM));
            distances.Add(LEFT, ScanAreaFromOrigin(filteredBmp, LEFT));

            // Sort by longest distance
            var sorted = from pair in distances orderby pair.Value descending select pair;
            Debug.WriteLine("DIRECTION {0}", sorted.First());

            // Find candidate
            var candidate = sorted.First();

            //// Replace candidate if we just came from there
            //if (GetOppositeDirection(candidate.Key) == m_LastWalkDirection)
            //    candidate = sorted.ElementAt(1);

            // Returrn candidate
            m_LastWalkDirection = candidate.Key;
            m_LastWalkDistance = candidate.Value;
            return candidate;
        }
        #endregion
    }
}
