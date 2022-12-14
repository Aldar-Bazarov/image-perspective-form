using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;

namespace ImagePerspective
{
    public partial class Form1 : Form
    {
        //private object currObject = null;
        //private bool status = false;
        private string fileName;

        //private Bitmap image;
        private Bitmap bmp;

        private WriteableBitmapWrapper _cutBitmap;
        private WriteableBitmapWrapper _sourceImage;

        PerspectiveControl PerspectiveBorder;

        //private Bitmap transformImage;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            this.BackColor = Color.AliceBlue;
            this.TopMost = true;
            this.TransparencyKey = SystemColors.Control;
            PerspectiveBorder = new PerspectiveControl(sourcePictureBox);
        }

        private void DrawPictureBoxes()
        {
            var MaxPictureBoxHeight = this.Height - 400;
            var MaxPictureBoxWidth = this.Width / 2 - 400;

            if (bmp.Height > bmp.Width && MaxPictureBoxHeight > (int)(MaxPictureBoxWidth * (bmp.Height / (double)bmp.Width)))
            {
                var height = (int)(MaxPictureBoxWidth * (bmp.Height / (double)bmp.Width));

                sourcePictureBox.Size = new Size(MaxPictureBoxWidth, height);
                sourcePictureBox.Location = new Point(200, (MaxPictureBoxHeight - sourcePictureBox.Height) / 2 + 200);
                sourcePictureBox.Image = new Bitmap(MaxPictureBoxWidth, height);

                transformedPictureBox.Size = new Size(MaxPictureBoxWidth, height);
                transformedPictureBox.Location = new Point(600 + MaxPictureBoxWidth, (MaxPictureBoxHeight - sourcePictureBox.Height) / 2 + 200);
                transformedPictureBox.Image = new Bitmap(MaxPictureBoxWidth, height);
            }
            else if (bmp.Height > bmp.Width)
            {
                var width = (int)(MaxPictureBoxHeight / (bmp.Height / (double)bmp.Width));

                sourcePictureBox.Size = new Size(width, MaxPictureBoxHeight);
                sourcePictureBox.Location = new Point((MaxPictureBoxWidth - sourcePictureBox.Width) / 2 + 200, 200);
                sourcePictureBox.Image = new Bitmap(width, MaxPictureBoxHeight);

                transformedPictureBox.Size = new Size(width, MaxPictureBoxHeight);
                transformedPictureBox.Location = new Point(MaxPictureBoxWidth + (MaxPictureBoxWidth - sourcePictureBox.Width) / 2 + 600, 200);
                transformedPictureBox.Image = new Bitmap(width, MaxPictureBoxHeight);
            }
            else
            {
                var height = (int)(MaxPictureBoxWidth * (bmp.Height / (double)bmp.Width));

                sourcePictureBox.Size = new Size(MaxPictureBoxWidth, height);
                sourcePictureBox.Location = new Point(200, (MaxPictureBoxHeight - sourcePictureBox.Height) / 2 + 200);
                sourcePictureBox.Image = new Bitmap(MaxPictureBoxWidth, height);

                transformedPictureBox.Size = new Size(MaxPictureBoxWidth, height);
                transformedPictureBox.Location = new Point(600 + MaxPictureBoxWidth, (MaxPictureBoxHeight - sourcePictureBox.Height) / 2 + 200);
                transformedPictureBox.Image = new Bitmap(MaxPictureBoxWidth, height);
            }

            using (var pg = Graphics.FromImage(sourcePictureBox.Image))
            {
                pg.Clear(Color.Black);
                pg.DrawImage(bmp, 0, 0, sourcePictureBox.Width, sourcePictureBox.Height);
            }

            using (var pg = Graphics.FromImage(transformedPictureBox.Image))
            {
                pg.Clear(Color.Black);
                pg.DrawImage(bmp, 0, 0, transformedPictureBox.Width, transformedPictureBox.Height);
            }
        }

        private void DrawTransformedImages(Bitmap img)
        {
            transformedPictureBox.Image = img;
        }

        /// <summary>
        /// Методы обработки кнопок взаимодействия с формой
        /// </summary>
        private void openFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:/Users/Bazarov/Desktop/images ";
                openFileDialog.Filter = "All Bitmap files | *.bmp; *.png; *.jpg;";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PerspectiveBorder.SetControl(this.sourcePictureBox);

                    fileName = openFileDialog.FileName;
                    bmp = new Bitmap(fileName);

                    DrawPictureBoxes();

                    _sourceImage = new WriteableBitmapWrapper(sourcePictureBox.Image);
                    _cutBitmap = new WriteableBitmapWrapper(_sourceImage.Width, _sourceImage.Height);
                }
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if (_sourceImage != null)
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Png Image|*.png";
                    saveFileDialog.Title = "Save Image";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var fs = (FileStream)saveFileDialog.OpenFile())
                        {
                            switch (saveFileDialog.FilterIndex)
                            {
                                case 1:
                                    transformedPictureBox.Image.Save(fs, ImageFormat.Jpeg);
                                    break;

                                case 2:
                                    transformedPictureBox.Image.Save(fs, ImageFormat.Bmp);
                                    break;

                                case 3:
                                    transformedPictureBox.Image.Save(fs, ImageFormat.Png);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void closeButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        #region
        /// <summary>
        /// Методы обработки событий мыши
        /// </summary>

        //private void corner_MouseDown(object sender, MouseEventArgs e)
        //{
        //    status = true;
        //    currObject = sender;
        //}

        //private void corner_MouseUp(object sender, MouseEventArgs e)
        //{
        //    status = false;
        //    currObject = null;

        //    if (_sourceImage != null)
        //    {
        //        UpdateImage();

        //        image = BitmapFromWriteableBitmap(_cutBitmap.Bitmap);

        //        DrawTransformedImages(transformImage);
        //    }
        //}

        //private void corner_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (status == true && _sourceImage != null)
        //    {
        //        var halfButtonWidth = topLeftButton.Width / 2;

        //        currObject
        //            .GetType()
        //            .GetProperty("Location")
        //            .SetValue(currObject, new Point(Cursor.Position.X - halfButtonWidth, Cursor.Position.Y - halfButtonWidth));
        //    }
        //}

        ///// <summary>
        ///// Метод обновления изображения
        ///// </summary>
        //private void UpdateImage()
        //{
        //    #region
        //    //var t1 = new Float2(-(topLeftButton.Location.X - sourcePictureBox.Location.X + topLeftButton.Width),
        //    //                    -(topLeftButton.Location.Y - sourcePictureBox.Location.Y + topLeftButton.Width));

        //    //var cursorPosition = new Float2((topRightButton.Location.X - sourcePictureBox.Location.X),
        //    //                    (topRightButton.Location.Y - sourcePictureBox.Location.Y + topRightButton.Width));
        //    //var diff = new Float2(sourcePictureBox.Width - cursorPosition.X, cursorPosition.Y);
        //    //var t2 = new Float2(sourcePictureBox.Width + diff.X, -diff.Y);

        //    //cursorPosition = new Float2((bottomLeftButton.Location.X - sourcePictureBox.Location.X + bottomLeftButton.Width),
        //    //                    (bottomLeftButton.Location.Y - sourcePictureBox.Location.Y));
        //    //diff = new Float2(cursorPosition.X, sourcePictureBox.Height - cursorPosition.Y);
        //    //var t3 = new Float2(-diff.X, sourcePictureBox.Height + diff.Y);

        //    //cursorPosition = new Float2((bottomRightButton.Location.X - sourcePictureBox.Location.X),
        //    //                    (bottomRightButton.Location.Y - sourcePictureBox.Location.Y));
        //    //diff = new Float2(cursorPosition.X - sourcePictureBox.Width, cursorPosition.Y - sourcePictureBox.Height);
        //    //var t4 = new Float2((cursorPosition.X - diff.X * 2),
        //    //                    (cursorPosition.Y - diff.Y * 2));
        //    #endregion
        //    var btmWidth = topLeftButton.Width;
        //    var t1 = new Float2(topLeftButton.Location.X - sourcePictureBox.Location.X + btmWidth, topLeftButton.Location.Y - sourcePictureBox.Location.Y + btmWidth);
        //    var t2 = new Float2(topRightButton.Location.X - sourcePictureBox.Location.X, topRightButton.Location.Y - sourcePictureBox.Location.Y + btmWidth);
        //    var t3 = new Float2(bottomLeftButton.Location.X - sourcePictureBox.Location.X + btmWidth, bottomLeftButton.Location.Y - sourcePictureBox.Location.Y);
        //    var t4 = new Float2(bottomRightButton.Location.X - sourcePictureBox.Location.X, bottomRightButton.Location.Y - sourcePictureBox.Location.Y);

        //    transformImage = CutImage(t1, t2, t3, t4);

        //    _sourceImage = new WriteableBitmapWrapper(transformImage);

        //    //var diffTL = new Float2(t1.X, t1.Y);
        //    //var diffTR = new Float2(sourcePictureBox.Width - t2.X, t2.Y);
        //    //var diffBl = new Float2(t3.X, sourcePictureBox.Height - t3.Y);
        //    //var diffBR = new Float2(sourcePictureBox.Width - t4.X, sourcePictureBox.Height - t4.Y);

        //    //var transform = Float3x3.Perspective(0, 0, _sourceImage.Width, _sourceImage.Height, t1, t2, t3, t4);

        //    //transform = transform.Invert();

        //    //for (var i = 0; i < 1; i++)
        //    //{
        //    //    using (_bitmap.Edit())
        //    //    {
        //    //        for (var x = 0; x < _sourceImage.Width; x++)
        //    //        {
        //    //            for (var y = 0; y < _sourceImage.Height; y++)
        //    //            {
        //    //                var tileCoord = transform.TransformPoint(new Float2(x, y));
        //    //                var c = _sourceImage.GetPixelOrDefault(tileCoord);
        //    //                _bitmap.SetPixel(x, y, c);
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //}

        //private double FindTriangleSquare(Float2 p1, Float2 p2, Float2 p3)
        //{   
        //    var p1p2 = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        //    var p1p3 = Math.Sqrt(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p1.Y - p3.Y, 2));
        //    var p2p3 = Math.Sqrt(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p2.Y - p3.Y, 2));

        //    var halfPerimeter = (p1p2 + p1p3 + p2p3) / 2;

        //    var triangleSquare = Math.Sqrt(
        //        halfPerimeter * (halfPerimeter - p1p2) * (halfPerimeter - p1p3) * (halfPerimeter - p2p3));

        //    return triangleSquare;
        //}

        ///// Обрезать изображение
        //private Bitmap CutImage(Float2 TL, Float2 TR, Float2 BL, Float2 BR)
        //{
        //    var outBmp = new Bitmap(sourcePictureBox.Width, sourcePictureBox.Image.Height);

        //    var firstBigTriangle = FindTriangleSquare(TL, TR, BL);

        //    var secondBigTriangle = FindTriangleSquare(TR, BL, BR);

        //    var neededQuadrilateralSquare = Math.Round(firstBigTriangle + secondBigTriangle);

        //    for (int x = 0; x < sourcePictureBox.Image.Width; x++)
        //    {
        //        for (int y = 0; y < sourcePictureBox.Image.Height; y++)
        //        {
        //            var currentPoint = new Float2(x, y);
        //            var firstSmallTriangle = FindTriangleSquare(TL, TR, currentPoint);
        //            var secondSmallTriangle = FindTriangleSquare(TL, BL, currentPoint);
        //            var thirdSmallTriangle = FindTriangleSquare(BR, TR, currentPoint);
        //            var fourthSmallTriangle = FindTriangleSquare(BR, BL, currentPoint);
        //            var currentQuadrilateralSquare = Math.Round(firstSmallTriangle + secondSmallTriangle + thirdSmallTriangle + fourthSmallTriangle);
        //            if (neededQuadrilateralSquare >= currentQuadrilateralSquare - 5 
        //                && neededQuadrilateralSquare <= currentQuadrilateralSquare + 5)
        //            {
        //                var bmp = (Bitmap)(sourcePictureBox.Image);
        //                outBmp.SetPixel(x, y, bmp.GetPixel(x, y));
        //            }
        //        }
        //    }

        //    return outBmp;
        //}

        /// <summary>
        /// Методы конвертации WriteableBitmap в Bitmap
        /// </summary>
        private static Bitmap BitmapFromWriteableBitmap(WriteableBitmap writeBmp)
        {
            Bitmap bmp;
            using (var outStream = new MemoryStream())
            {
                var enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
                enc.Save(outStream);
                bmp = new Bitmap(outStream);
            }
            return bmp;
        }

        #endregion

        private void transformButton_Click(object sender, EventArgs e)
        {
            var corners = new List<IntPoint>
            {
                new IntPoint(PerspectiveBorder.topLeft.X, PerspectiveBorder.topLeft.Y),
                new IntPoint(PerspectiveBorder.topRight.X, PerspectiveBorder.topRight.Y),
                new IntPoint(PerspectiveBorder.bottomRight.X, PerspectiveBorder.bottomRight.Y),
                new IntPoint(PerspectiveBorder.bottomLeft.X, PerspectiveBorder.bottomLeft.Y)
            };

            var filter = new QuadrilateralTransformation(corners, sourcePictureBox.Width, sourcePictureBox.Height);
            Bitmap result = filter.Apply((Bitmap)sourcePictureBox.Image);

            transformedPictureBox.Image = result;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            PerspectiveBorder.SetControl(this.sourcePictureBox);

            bmp = new Bitmap(fileName);

            PerspectiveBorder.topLeft = new Point(10, 10);
            PerspectiveBorder.topRight = new Point(sourcePictureBox.Width - 10, 10);
            PerspectiveBorder.bottomLeft = new Point(10, sourcePictureBox.Height - 10);
            PerspectiveBorder.bottomRight = new Point(sourcePictureBox.Width - 10, sourcePictureBox.Height - 10);

            DrawPictureBoxes();
        }
    }
}
