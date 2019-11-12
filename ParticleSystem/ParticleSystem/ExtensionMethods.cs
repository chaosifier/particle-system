using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParticleSystem
{
    public static class ExtensionMethods
    {
        public static SKColor ToSKColor(this System.Drawing.Color inColor)
        {
            return new SKColor((byte)inColor.R, (byte)inColor.G, (byte)inColor.B, (byte)inColor.A);
        }
    }
}
