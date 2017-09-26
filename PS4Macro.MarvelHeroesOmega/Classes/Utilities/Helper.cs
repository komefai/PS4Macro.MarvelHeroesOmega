// PS4Macro.MarvelHeroesOmega (File: Classes/Helper.cs)
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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace PS4Macro.MarvelHeroesOmega
{
    public class Helper
    {
        public static Bitmap PosterizeFilter(Bitmap bmp, byte posterizationInterval = 150)
        {
            SimplePosterization filter = new SimplePosterization();
            filter.PosterizationInterval = posterizationInterval;
            return filter.Apply(bmp);
        }

        public static Bitmap SobelEdgeFilter(Bitmap bmp)
        {
            var converted = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format8bppIndexed);
            SobelEdgeDetector filter = new SobelEdgeDetector();
            return filter.Apply(converted);
        }

        public static bool AllOneColor(Bitmap bmp)
        {
            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmpData.Stride * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            bool AllOneColor = true;
            for (int index = 0; index < rgbValues.Length; index++)
            {
                //compare the current A or R or G or B with the A or R or G or B at position 0,0.
                if (rgbValues[index] != rgbValues[index % 4])
                {
                    AllOneColor = false;
                    break;
                }
            }
            // Unlock the bits.
            bmp.UnlockBits(bmpData);
            return AllOneColor;
        }

        public static double DegreesToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        // http://www.petercollingridge.co.uk/blog/finding-angle-around-ellipse
        public static Point EllipseDegreesToPoint(double a, double b, double degrees, double offsetX = 0, double offsetY = 0)
        {
            double radians = DegreesToRadians(degrees);

            // x = a.cos(θ), y = b.sin(θ)
            int x = (int)Math.Round((Math.Cos(radians) * a) + offsetX);
            int y = (int)Math.Round((Math.Sin(radians) * b) + offsetY);

            return new Point(x, y);
        }

        public static PointF DegreesToPoint(double radius, double degrees)
        {
            double radians = DegreesToRadians(degrees);

            // x = r.cos(θ), y = r.sin(θ)
            double x = Math.Cos(radians) * radius;
            double y = Math.Sin(radians) * radius;

            return new PointF((float)x, (float)y);
        }

        public static Point DegreesToAnalog(double degrees)
        {
            Point p = EllipseDegreesToPoint(1, 1, degrees);
            return new Point(p.X * 255, p.Y * 255);
        }
    }
}
