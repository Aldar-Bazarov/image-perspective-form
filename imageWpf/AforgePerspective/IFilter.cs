using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImagePerspective
{
    interface IFilter
    {
        Bitmap Apply(Bitmap image);
        Bitmap Apply(BitmapData imageData);
        UnmanagedImage Apply(UnmanagedImage image);
        void Apply(UnmanagedImage sourceImage, UnmanagedImage destinationImage);
    }
}
