// PS4Macro.MarvelHeroesOmega (File: Classes/LootSystem.cs)
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
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace PS4Macro.MarvelHeroesOmega
{
    public class LootSystem
    {
        public static int FilteredEternitySplinter_Primary = 0xE14BE1;
        public static int FilteredEternitySplinter_Secondary = 0xE14B4B;
        public static RGB FilteredEternitySplinter_Primary_RGB = new RGB(225, 75, 225);

        // Scan area crop rectangle
        public static Rectangle R_ScanArea = new Rectangle()
        {
            //X = 223,
            //Y = 144,
            //Width = 556,
            //Height = 379
            X = 0,
            Y = 81,
            Width = 1008,
            Height = 567
        };

        // Blob counter for eternity spirit
        public static BlobCounter EternitySplinterBlobCounter = new BlobCounter()
        {
            FilterBlobs = true,
            MinWidth = 15,
            MinHeight = 15,
            MaxWidth = 28,
            MaxHeight = 28

        };

        public static Bitmap EternitySplinterFilter(Bitmap bmp)
        {
            var newBmp = Helper.PosterizeFilter(bmp);
            //ColorFiltering filter = new ColorFiltering();
            //filter.Red = new IntRange(100, 255);
            //filter.Green = new IntRange(0, 75);
            //filter.Green = new IntRange(0, 75);
            //filter.ApplyInPlace(newBmp);

            EuclideanColorFiltering filter = new EuclideanColorFiltering
            {
                Radius = 40,
                CenterColor = FilteredEternitySplinter_Primary_RGB
            };
            filter.ApplyInPlace(newBmp);
            return newBmp;
        }

        public static Rectangle[] GetPossibleEternitySplinters(Bitmap bmp)
        {
            // Process input image
            EternitySplinterBlobCounter.ProcessImage(bmp);
            // Get information about detected objects
            Rectangle[] rectangles = EternitySplinterBlobCounter.GetObjectsRectangles();
            return rectangles;
        }

        public static Blob[] GetPossibleEternitySplintersAsBlobs(Bitmap bmp)
        {
            // Process input image
            EternitySplinterBlobCounter.ProcessImage(bmp);
            // Get information about detected objects
            Blob[] blobs = EternitySplinterBlobCounter.GetObjectsInformation();
            return blobs;
        }

        public Rectangle[] DetectEternitySplinters(Script script)
        {
            // Crop
            var bmp = script.CropFrame(R_ScanArea);
            // Apply filter
            Bitmap filteredBmp = EternitySplinterFilter(bmp);

            // Find possible blobs
            Rectangle[] possibleBlobs = GetPossibleEternitySplinters(filteredBmp);

            // Further processing
            // ...

            return possibleBlobs;
        }
    }
}
