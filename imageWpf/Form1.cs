using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;

namespace imageWpf
{
    public partial class Form1 : Form
    {
        private object currObject = null;
        bool status = false;
        private Graphics g;
        string fileName;
        Bitmap image;
        Bitmap bmp = new Bitmap(@"C:\Users\Bazarov\Desktop\images\Безымянный_compress.jpg");

        private WriteableBitmapWrapper _bitmap;
        private WriteableBitmapWrapper _sourceImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            g = this.CreateGraphics();
        }

        private void DrawBox()
        {
            using (var pen = new Pen(Color.FromArgb(255, 0, 0, 0), 2))
            {
                g.DrawLine(pen, topLeftButton.Location.X, topLeftButton.Location.Y, topRightButton.Location.X, topRightButton.Location.Y);
                g.DrawLine(pen, topRightButton.Location.X, topRightButton.Location.Y, bottomRightButton.Location.X, bottomRightButton.Location.Y);
                g.DrawLine(pen, bottomRightButton.Location.X, bottomRightButton.Location.Y, bottomLeftButton.Location.X, bottomLeftButton.Location.Y);
                g.DrawLine(pen, bottomLeftButton.Location.X, bottomLeftButton.Location.Y, topLeftButton.Location.X, topLeftButton.Location.Y);
            }
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:/Users/Bazarov/Desktop/images ";
                openFileDialog.Filter = "All Bitmap files | *.bmp; *.png; *.jpg;";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;

                    _sourceImage = new WriteableBitmapWrapper(fileName);
                    _bitmap = new WriteableBitmapWrapper(_sourceImage.Width, _sourceImage.Height);

                    topLeftButton.Location = new Point(100, 100);
                    topRightButton.Location = new Point(_sourceImage.Width + 100, 100);
                    bottomLeftButton.Location = new Point(100, _sourceImage.Height + 100);
                    bottomRightButton.Location = new Point(_sourceImage.Width + 100, _sourceImage.Height + 100);

                    topLeftButton.Visible = true;
                    topRightButton.Visible = true;
                    bottomLeftButton.Visible = true;
                    bottomRightButton.Visible = true;

                    g.Clear(BackColor);
                    DrawBox();
                    Bitmap image = BitmapFromWriteableBitmap(_bitmap.Bitmap);
                    g.DrawImage(image, 100, 100) ;
                }
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if (_sourceImage != null)
            {
                //image.Save(@"C:\Users\Bazarov\Desktop\images\fileName-wpf.png", ImageFormat.Png);
                bmp = new Bitmap(@"C:\Users\Bazarov\Desktop\images\test1.png");
                bmp.Save(@"C:\Users\Bazarov\Desktop\images\fileName-wpf.png", ImageFormat.Png);
            }

            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";
            //saveFileDialog1.Title = "Save an Image File";
            //saveFileDialog1.ShowDialog();

            //if (saveFileDialog1.FileName != "")
            //{
            //    FileStream fs = (FileStream)saveFileDialog1.OpenFile();
            //    switch (saveFileDialog1.FilterIndex)
            //    {
            //        case 1:
            //            g.Dispose();
            //            //image.Dispose();
            //            image.Save(fs, ImageFormat.Jpeg);
            //            break;

            //        case 2:
            //            image.Save(fs, ImageFormat.Bmp);
            //            break;
            //    }

            //    fs.Close();
            //}
        }

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
                image = BitmapFromWriteableBitmap(_bitmap.Bitmap);
                g.DrawImage(image, 100, 100);
            }
        }

        private void corner_MouseMove(object sender, MouseEventArgs e)
        {
            if (status == true && _sourceImage != null)
            {
                currObject
                    .GetType()
                    .GetProperty("Location")
                    .SetValue(currObject, new Point(Cursor.Position.X - 5, Cursor.Position.Y - 25));

                g.Clear(BackColor);

                DrawBox();

                UpdateImage();
            }
        }

        private void UpdateImage()
        {
            var t1 = new Float2((float)topLeftButton.Location.X, (float)topLeftButton.Location.Y);
            var t2 = new Float2((float)topRightButton.Location.X, (float)topRightButton.Location.Y);
            var t3 = new Float2((float)bottomLeftButton.Location.X, (float)bottomLeftButton.Location.Y);
            var t4 = new Float2((float)bottomRightButton.Location.X, (float)bottomRightButton.Location.Y);

            var transform = Float3x3.Perspective(100, 100, _sourceImage.Width, _sourceImage.Height, t1, t2, t3, t4);
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

        private static Bitmap BitmapFromWriteableBitmap(WriteableBitmap writeBmp)
        {
            Bitmap bmp;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
                enc.Save(outStream);
                bmp = new Bitmap(outStream);
            }
            return bmp;
        }
    }
}
