using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;


namespace ImagePerspective
{
    interface IFilterInformation
    {
        Dictionary<PixelFormat, PixelFormat> FormatTranslations { get; }
    }
}
