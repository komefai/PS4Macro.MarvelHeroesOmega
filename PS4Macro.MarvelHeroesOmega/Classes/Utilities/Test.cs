// PS4Macro.MarvelHeroesOmega (File: Classes/Test.cs)
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
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace PS4Macro.MarvelHeroesOmega
{
    class Test
    {
        const string PATH = @"C:\Users\me\Documents\Visual Studio 2015\Projects\PS4Macro.MarvelHeroesOmega\PS4Macro.MarvelHeroesOmega\bin\Debug";

        public static void Load()
        {
            Bitmap bmp = Image.FromFile(PATH + @"\health2.jpg") as Bitmap;
            SimplePosterization filter = new SimplePosterization();
            filter.PosterizationInterval = 150;
            Bitmap newBmp = filter.Apply(bmp);

            newBmp.Save(PATH + @"\out2.png");
        }

        public static void Start()
        {
            Bitmap bmp = Image.FromFile(PATH + @"\test.png") as Bitmap;
            SimplePosterization filter = new SimplePosterization();
            filter.PosterizationInterval = 150;
            Bitmap newBmp = filter.Apply(bmp);

            newBmp.Save(PATH + @"\outtest.png");
        }

        public static void TestEdge()
        {
            try
            {
                Bitmap bmp = Image.FromFile(PATH + @"\test.png") as Bitmap;
                bmp = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format8bppIndexed);

                //AForge.Imaging.Image.SetGrayscalePalette(bmp);
                SobelEdgeDetector filter = new SobelEdgeDetector();
                Bitmap newBmp = filter.Apply(bmp);

                newBmp.Save(PATH + @"\outtest.png");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public static Bitmap CropAtRect(Bitmap b, Rectangle r)
        {
            Bitmap nb = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(nb);
            g.DrawImage(b, -r.X, -r.Y);
            return nb;
        }
    }
}
