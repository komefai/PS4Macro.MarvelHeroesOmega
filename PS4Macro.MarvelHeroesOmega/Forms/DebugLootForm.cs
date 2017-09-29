// PS4Macro.MarvelHeroesOmega (File: Forms/DebugLootForm.cs)
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;
using PS4MacroAPI.Internal;

namespace PS4Macro.MarvelHeroesOmega
{
    public partial class DebugLootForm : Form
    {
        protected bool validData;
        string path;
        protected System.Drawing.Image image;
        protected Thread getImageThread;

        public DebugLootForm()
        {
            InitializeComponent();
        }

        private bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = e.Data.GetData("FileDrop") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is string))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp"))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        private Size ParseMinSize()
        {
            try
            {
                int width = int.Parse(minWidthTextBox.Text.Trim());
                int height = int.Parse(minHeightTextBox.Text.Trim());
                return new Size(width, height);
            }
            catch (Exception)
            {
                return new Size(-1, -1);
            }
        }

        private void CompareImages()
        {
            if (imageAPictureBox.Image == null)
                return;

            var minSize = ParseMinSize();

            if (minSize.Width < 0 || minSize.Height < 0)
                return;

            Bitmap newBmp = LootSystem.EternitySplinterFilter(imageAPictureBox.Image as Bitmap);

            // locate objects using blob counter
            BlobCounter blobCounter = new BlobCounter()
            {
                FilterBlobs = true,
                MinWidth = minSize.Width,
                MinHeight = minSize.Height,
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

            imageBPictureBox.Image = newBmp;
        }

        private void OnImageChanged(System.Drawing.Image image, PictureBox pictureBox)
        {

        }

        private void compareButton_Click(object sender, EventArgs e)
        {
            CompareImages();
        }

        private void ImageHashForm_DragEnter(object sender, DragEventArgs e)
        {
            string filename;
            validData = GetFilename(out filename, e);
            if (validData)
            {
                path = filename;
                getImageThread = new Thread(new ThreadStart(() =>
                {
                    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        image = System.Drawing.Image.FromStream(stream);
                    }
                }));

                getImageThread.Start();
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void ImageHashForm_DragDrop(object sender, DragEventArgs e)
        {
            if (validData)
            {
                while (getImageThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }

                PictureBox pb = null;

                if (this.PointToClient(new System.Drawing.Point(e.X, e.Y)).X <= Size.Width / 2)
                    pb = imageAPictureBox;
                else
                    pb = imageBPictureBox;

                pb.Image = image;
                OnImageChanged(image, pb);
            }
        }
    }
}
