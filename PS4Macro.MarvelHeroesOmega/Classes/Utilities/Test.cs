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
using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;
using Image = System.Drawing.Image;

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

        public static void ColorFilter()
        {
            try
            {
                Bitmap bmp = Image.FromFile(PATH + @"\test.png") as Bitmap;
                ColorFiltering filter = new ColorFiltering();
                filter.Red = new IntRange(100, 255);
                filter.Green = new IntRange(0, 75);
                filter.Green = new IntRange(0, 75);

                Bitmap newBmp = filter.Apply(bmp);

                newBmp.Save(PATH + @"\outtest.png");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        public static void EternitySplinterFilter()
        {
            try
            {
                Bitmap bmp = Image.FromFile(PATH + @"\test.png") as Bitmap;
                Bitmap newBmp = LootSystem.EternitySplinterFilter(bmp);

                newBmp.Save(PATH + @"\outtest.png");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

        }

        public static void EternitySplinterDraw()
        {
            try
            {
                Bitmap bmp = Image.FromFile(PATH + @"\test.png") as Bitmap;
                Bitmap newBmp = LootSystem.EternitySplinterFilter(bmp);

                // locate objects using blob counter
                BlobCounter blobCounter = new BlobCounter()
                {
                    FilterBlobs = true,
                    MinWidth = 15,
                    MinHeight = 15,
                    MaxWidth = 28,
                    MaxHeight = 28
                };

                // Process input image
                blobCounter.ProcessImage(newBmp);
                // Get information about detected objects
                Blob[] blobs = blobCounter.GetObjectsInformation();

                // create Graphics object to draw on the image and a pen
                Graphics g = Graphics.FromImage(newBmp);
                Pen bluePen = new Pen(Color.Blue, 2);
                // check each object and draw circle around objects, which
                // are recognized as circles
                for (int i = 0, n = blobs.Length; i < n; i++)
                {
                    List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
                    List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);

                    g.DrawPolygon(bluePen, Helper.AForgeToPointsArray(corners));
                }

                bluePen.Dispose();
                g.Dispose();

                
                newBmp.Save(PATH + @"\outtest.png");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

        }

        public static void EternitySplinterDetect()
        {
            try
            {
                Bitmap bmp = Image.FromFile(PATH + @"\test.png") as Bitmap;
                Bitmap newBmp = LootSystem.EternitySplinterFilter(bmp);

                // locate objects using blob counter
                BlobCounter blobCounter = new BlobCounter()
                {
                    FilterBlobs = true,
                    MinWidth = 2,
                    MinHeight = 2,
                    MaxWidth = 28,
                    MaxHeight = 28
                };

                // Process input image
                blobCounter.ProcessImage(newBmp);
                // Get information about detected objects
                Blob[] blobs = blobCounter.GetObjectsInformation();

                // create Graphics object to draw on the image and a pen
                Graphics g = Graphics.FromImage(newBmp);
                Pen bluePen = new Pen(Color.Blue, 2);
                // check each object and draw circle around objects, which
                // are recognized as circles
                for (int i = 0, n = blobs.Length; i < n; i++)
                {
                    List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
                    List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);

                    g.DrawPolygon(bluePen, Helper.AForgeToPointsArray(corners));
                }

                bluePen.Dispose();
                g.Dispose();


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
