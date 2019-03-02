using System;
using System.Drawing;

namespace PaletteMixr
{
    internal static class ColorExtensions
    {
        internal static HslColor ToHsl(this Color color)
        {
            (double r, double g, double b) = Normalise(color);

            (double min, double max) = GetMinAndMax(r, g, b);

            double h, s, l;

            l = CalculateLuminosity(min, max);

            if (ShadeOfGrey(min, max))
            {
                h = s = 0;
            }
            else
            {
                double minMaxDelta = max - min;

                s = CalculateSaturation(min, max, l, minMaxDelta);
                h = CalculateHue(r, g, b, max, minMaxDelta);
            }

            return new HslColor(h, s, l);
        }

        private static (double r, double g, double b) Normalise(Color color)
        {
            return (color.R / 255d, color.G / 255d, color.B / 255d);
        }

        private static (double min, double max) GetMinAndMax(double r, double g, double b)
        {
            double min = Math.Min(r, Math.Min(g, b));
            double max = Math.Max(r, Math.Max(g, b));

            return (min, max);
        }

        private static bool ShadeOfGrey(double min, double max)
        {
            return max == min;
        }

        private static double CalculateLuminosity(double min, double max)
        {
            return (max + min) / 2d;
        }

        private static double CalculateSaturation(double min, double max, double l, double minMaxDelta)
        {
            if (l > 0.5d)
            {
                return minMaxDelta / (2d - minMaxDelta);
            }
            else
            {
                return minMaxDelta / (max + min);
            }
        }

        private static double CalculateHue(double r, double g, double b, double max, double minMaxDelta)
        {
            double h;
            if (max == r)
            {
                double v = g < b ? 6d : 0;
                h = ((g - b) / minMaxDelta) + v;
            }
            else if (max == g)
            {
                h = ((b - r) / minMaxDelta) + 2d;
            }
            else
            {
                h = ((r - g) / minMaxDelta) + 4d;
            }

            return h /= 6;
        }
    }
}
