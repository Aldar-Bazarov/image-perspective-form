using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;

namespace imageWpf
{
    public partial class Form1 : Form
    {
        private object currObject = null;
        private bool status = false;
        private string fileName;

        private Bitmap image;
        private Bitmap bmp;

        private WriteableBitmapWrapper _bitmap;
        private WriteableBitmapWrapper _sourceImage;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            this.BackColor = Color.AliceBlue;
            this.TopMost = true;
            this.TransparencyKey = SystemColors.Control;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileName = @"C:\Users\Bazarov\Desktop\images\HIMq1Bt47rQ.jpg";

            bmp = new Bitmap(fileName);


            //List<IntPoint> corners = new List<IntPoint>();

            //corners.Add(new IntPoint(x1, y1));
            //corners.Add(new IntPoint(x2, y2));
            //corners.Add(new IntPoint(x3, y3));
            //corners.Add(new IntPoint(x4, y4));

            //QuadrilateralTransformation filter = new QuadrilateralTransformationBilinear(corners, NewWidth, NewHeight);
            //Bitmap newImage = filter.Apply(image);


            DrawPictureBoxes();
            DrawButtons();

            _sourceImage = new WriteableBitmapWrapper(sourcePictureBox.Image);
            _bitmap = new WriteableBitmapWrapper(_sourceImage.Width, _sourceImage.Height);
        }

        /// <summary>
        /// Методы рисования
        /// </summary>
        private void DrawButtons()
        {
            var buttonWidth = topLeftButton.Width;

            topLeftButton.Location = new Point(sourcePictureBox.Location.X - buttonWidth, sourcePictureBox.Location.Y - buttonWidth);
            topRightButton.Location = new Point(sourcePictureBox.Location.X + sourcePictureBox.Width, sourcePictureBox.Location.Y - buttonWidth);
            bottomLeftButton.Location = new Point(sourcePictureBox.Location.X - buttonWidth, sourcePictureBox.Height + sourcePictureBox.Location.Y);
            bottomRightButton.Location = new Point(sourcePictureBox.Location.X + sourcePictureBox.Width, sourcePictureBox.Location.Y + sourcePictureBox.Height);

            topLeftButton.Visible = true;
            topRightButton.Visible = true;
            bottomLeftButton.Visible = true;
            bottomRightButton.Visible = true;

            topLeftButton.BringToFront();
            topRightButton.BringToFront();
            bottomLeftButton.BringToFront();
            bottomRightButton.BringToFront();
        }

        private void DrawPictureBoxes()
        {
            var MaxPictureBoxHeight = this.Height - 200;
            var MaxPictureBoxWidth = this.Width / 2 - 200;

            if (bmp.Height > bmp.Width && MaxPictureBoxHeight > (int)(MaxPictureBoxWidth * (bmp.Height / (double)bmp.Width)))
            {
                var height = (int)(MaxPictureBoxWidth * (bmp.Height / (double)bmp.Width));

                sourcePictureBox.Size = new Size(MaxPictureBoxWidth, height);
                sourcePictureBox.Location = new Point(100, (MaxPictureBoxHeight - sourcePictureBox.Height) / 2 + 100);
                sourcePictureBox.Image = new Bitmap(MaxPictureBoxWidth, height);

                transformedPictureBox.Size = new Size(MaxPictureBoxWidth, height);
                transformedPictureBox.Location = new Point(300 + MaxPictureBoxWidth, (MaxPictureBoxHeight - sourcePictureBox.Height) / 2 + 100);
                transformedPictureBox.Image = new Bitmap(MaxPictureBoxWidth, height);
            }
            else if (bmp.Height > bmp.Width)
            {
                var width = (int)(MaxPictureBoxHeight / (bmp.Height / (double)bmp.Width));

                sourcePictureBox.Size = new Size(width, MaxPictureBoxHeight);
                sourcePictureBox.Location = new Point((MaxPictureBoxWidth - sourcePictureBox.Width) / 2 + 100, 100);
                sourcePictureBox.Image = new Bitmap(width, MaxPictureBoxHeight);

                transformedPictureBox.Size = new Size(width, MaxPictureBoxHeight);
                transformedPictureBox.Location = new Point(MaxPictureBoxWidth + (MaxPictureBoxWidth - sourcePictureBox.Width) / 2 + 300, 100);
                transformedPictureBox.Image = new Bitmap(width, MaxPictureBoxHeight);
            }
            else
            {
                var height = (int)(MaxPictureBoxWidth * (bmp.Height / (double)bmp.Width));

                sourcePictureBox.Size = new Size(MaxPictureBoxWidth, height);
                sourcePictureBox.Location = new Point(100, (MaxPictureBoxHeight - sourcePictureBox.Height) / 2 + 100);
                sourcePictureBox.Image = new Bitmap(MaxPictureBoxWidth, height);

                transformedPictureBox.Size = new Size(MaxPictureBoxWidth, height);
                transformedPictureBox.Location = new Point(300 + MaxPictureBoxWidth, (MaxPictureBoxHeight - sourcePictureBox.Height) / 2 + 100);
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
                    fileName = openFileDialog.FileName;
                    bmp = new Bitmap(fileName);

                    DrawPictureBoxes();
                    DrawButtons();

                    _sourceImage = new WriteableBitmapWrapper(sourcePictureBox.Image);
                    _bitmap = new WriteableBitmapWrapper(_sourceImage.Width, _sourceImage.Height);
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

        /// <summary>
        /// Методы обработки событий мыши
        /// </summary>

        private void corner_MouseDown(object sender, MouseEventArgs e)
        {
            status = true;
            currObject = sender;
        }

        private void corner_MouseUp(object sender, MouseEventArgs e)
        {
            status = false;
            currObject = null;

            if (_sourceImage != null)
            {
                UpdateImage();

                image = BitmapFromWriteableBitmap(_bitmap.Bitmap);

                DrawTransformedImages(image);
            }
        }

        private void corner_MouseMove(object sender, MouseEventArgs e)
        {
            if (status == true && _sourceImage != null)
            {
                var halfButtonWidth = topLeftButton.Width / 2;

                currObject
                    .GetType()
                    .GetProperty("Location")
                    .SetValue(currObject, new Point(Cursor.Position.X - halfButtonWidth, Cursor.Position.Y - halfButtonWidth));
            }
        }

        /// <summary>
        /// Метод обновления изображения
        /// </summary>
        private void UpdateImage()
        {
            var t1 = new Float2(-(topLeftButton.Location.X - sourcePictureBox.Location.X + topLeftButton.Width),
                                -(topLeftButton.Location.Y - sourcePictureBox.Location.Y + topLeftButton.Width));

            var cursorPosition = new Float2((topRightButton.Location.X - sourcePictureBox.Location.X),
                                (topRightButton.Location.Y - sourcePictureBox.Location.Y + topRightButton.Width));
            var diff = new Float2(sourcePictureBox.Width - cursorPosition.X, cursorPosition.Y);
            var t2 = new Float2(sourcePictureBox.Width + diff.X, -diff.Y);

            cursorPosition = new Float2((bottomLeftButton.Location.X - sourcePictureBox.Location.X + bottomLeftButton.Width),
                                (bottomLeftButton.Location.Y - sourcePictureBox.Location.Y));
            diff = new Float2(cursorPosition.X, sourcePictureBox.Height - cursorPosition.Y);
            var t3 = new Float2(-diff.X, sourcePictureBox.Height + diff.Y);

            cursorPosition = new Float2((bottomRightButton.Location.X - sourcePictureBox.Location.X),
                                (bottomRightButton.Location.Y - sourcePictureBox.Location.Y));
            diff = new Float2(cursorPosition.X - sourcePictureBox.Width, cursorPosition.Y - sourcePictureBox.Height);
            var t4 = new Float2((cursorPosition.X - diff.X * 2),
                                (cursorPosition.Y - diff.Y * 2));

            var transform = Float3x3.Perspective(0, 0, _sourceImage.Width, _sourceImage.Height, t1, t2, t3, t4);

            transform = transform.Invert();

            for (var i = 0; i < 1; i++)
            {
                using (_bitmap.Edit())
                {
                    for (var x = 0; x < _sourceImage.Width; x++)
                    {
                        for (var y = 0; y < _sourceImage.Height; y++)
                        {
                            var tileCoord = transform.TransformPoint(new Float2(x, y));
                            var c = _sourceImage.GetPixelOrDefault(tileCoord);
                            _bitmap.SetPixel(x, y, c);
                        }
                    }
                }
            }
        }

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
    }
}
