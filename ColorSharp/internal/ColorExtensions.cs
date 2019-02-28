using System;
using System.Drawing;

namespace ColorSharp
{
    internal static class ColorExtensions
    {
        internal static HslColor ToHsl(this Color color)
        {
            double r = color.R / 255d;
            double g = color.G / 255d;
            double b = color.B / 255d;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));

            double h, s, l = (max + min) / 2d;

            if (max == min)
            {
                h = s = 0;
            }
            else
            {
                var d = max - min;
                if (l > 0.5d)
                {
                    s = d / (2d - max - min);
                }
                else
                {
                    s = d / (max + min);
                }

                if (max == r)
                {
                    h = ((g - b) / d) + (g < b ? 6d : 0);
                }
                else if(max == g)
                {
                    h = ((b - r) / d) + 2d;
                }
                else
                {
                    h = ((r - g) / d) + 4d;
                }

                h /= 6;
            }

            return new HslColor(h, s, l);
        }
    }
}
