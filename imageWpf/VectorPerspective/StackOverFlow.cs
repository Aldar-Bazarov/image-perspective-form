using System;
using System.Drawing;

namespace ImagePerspective
{
    class StackOverFlow
    {
        PointF[] _Corners = new PointF[4];
        string _Path = "";
        Color[,] _Px = new Color[1,1];
        // _Corners are, well, the 4 corners in the source image
        // _Px is an array of pixels extracted from the source image

        public void Rescale()
        {
            RescaleImage(
                _Corners[0],
                _Corners[1],
                _Corners[3],
                _Corners[2],
                100,
                100);
        }

        private void RescaleImage(PointF TL, PointF TR, PointF LL, PointF LR, int sx, int sy)
        {
            var bmpOut = new Bitmap(sx, sy);

            for (int x = 0; x < sx; x++)
            {
                for (int y = 0; y < sy; y++)
                {
                    /*
                     * relative position
                     */
                    double rx = (double)x / sx;
                    double ry = (double)y / sy;

                    /*
                     * get top and bottom position
                     */
                    double topX = TL.X + rx * (TR.X - TL.X);
                    double topY = TL.Y + rx * (TR.Y - TL.Y);
                    double bottomX = LL.X + rx * (LR.X - LL.X);
                    double bottomY = LL.Y + rx * (LR.Y - LL.Y);

                    /*
                     * select center between top and bottom point
                     */
                    double centerX = topX + ry * (bottomX - topX);
                    double centerY = topY + ry * (bottomY - topY);

                    /*
                     * store result
                     */
                    var c = PolyColor(centerX, centerY);
                    bmpOut.SetPixel(x, y, c);
                }
            }

            bmpOut.Save(_Path + "out5 rescale out.bmp");
        }

        private Color PolyColor(double x, double y)
        {
            // get fractions
            double xf = x - (int)x;
            double yf = y - (int)y;

            // 4 colors - we're flipping sides so we can use the distance instead of inverting it later
            Color cTL = _Px[(int)y + 1, (int)x + 1];
            Color cTR = _Px[(int)y + 1, (int)x + 0];
            Color cLL = _Px[(int)y + 0, (int)x + 1];
            Color cLR = _Px[(int)y + 0, (int)x + 0];

            // 4 distances
            double dTL = Math.Sqrt(xf * xf + yf * yf);
            double dTR = Math.Sqrt((1 - xf) * (1 - xf) + yf * yf);
            double dLL = Math.Sqrt(xf * xf + (1 - yf) * (1 - yf));
            double dLR = Math.Sqrt((1 - xf) * (1 - xf) + (1 - yf) * (1 - yf));

            // 4 parts
            double factor = 1.0 / (dTL + dTR + dLL + dLR);
            dTL *= factor;
            dTR *= factor;
            dLL *= factor;
            dLR *= factor;

            // accumulate parts
            double r = dTL * cTL.R + dTR * cTR.R + dLL * cLL.R + dLR * cLR.R;
            double g = dTL * cTL.G + dTR * cTR.G + dLL * cLL.G + dLR * cLR.G;
            double b = dTL * cTL.B + dTR * cTR.B + dLL * cLL.B + dLR * cLR.B;

            Color c = Color.FromArgb((int)(r + 0.5), (int)(g + 0.5), (int)(b + 0.5));

            return c;
        }
    }
}
