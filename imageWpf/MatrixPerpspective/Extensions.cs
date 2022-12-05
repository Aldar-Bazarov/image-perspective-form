using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImagePerspective
{
    public static class Extensions
    {
        public static bool EpsilonEquals(this float f, float other, float epsilon)
        {
            return Math.Abs(f - other) <= epsilon;
        }
        public static Image Crop(this Image image, Rectangle selection)
        {
            Bitmap bmp = image as Bitmap;

            // Check if it is a bitmap:
            if (bmp == null)
                throw new ArgumentException("No valid bitmap");

            // Crop the image:
            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);

            // Release the resources:
            image.Dispose();

            return cropBmp;
        }

        public static Bitmap CropRotatedRect(this Bitmap source, Rectangle rect, float angle, bool HighQuality)
        {
            Bitmap result = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = HighQuality ? InterpolationMode.HighQualityBicubic : InterpolationMode.Default;
                using (Matrix mat = new Matrix())
                {
                    mat.Translate(-rect.Location.X, -rect.Location.Y);
                    mat.RotateAt(angle, rect.Location);
                    g.Transform = mat;
                    g.DrawImage(source, new Point(0, 0));
                }
            }
            return result;
        }
    }
}
