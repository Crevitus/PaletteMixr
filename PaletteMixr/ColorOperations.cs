using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PaletteMixr
{
    public static class ColorOperations
    {
        public static Func<Color, Color> ShiftHue(double angle)
        {
            return (color) =>
            {
                var hsl = color.ToHsl();
                var h = (hsl.H + (angle / 360d));
                while (h < 0d) h++;

                return new HslColor(h, hsl.S, hsl.L).ToColor();
            };
        }

        public static Func<Color, Color> Desaturate(double factor) {
            return (color) =>
            {
                var hsl = color.ToHsl();
                var s = Math.Max(Math.Min(hsl.S * (factor / 100d), 100d), 0d);

                return new HslColor(hsl.H, s, hsl.L).ToColor();
            };
        }

        public static Func<Color, Color> Saturate(double factor)
        {
            return (color) =>
            {
                var hsl = color.ToHsl();
                var s = 100d - Math.Max(Math.Min((100d - hsl.S) * (factor / 100d), 100d), 0);

                return new HslColor(hsl.H, s, hsl.L).ToColor();
            };
        }

        public static Func<Color, Color> Darken(double factor)
        {
            return (color) =>
            {
                var hsl = color.ToHsl();
                var l = Math.Max(Math.Min(hsl.L * (factor / 100d), 100d), 0d);

                return new HslColor(hsl.H, hsl.S, l).ToColor();
            };
        }

        public static Func<Color, Color> Brighten(double factor)
        {
            return (color) =>
            {
                var hsl = color.ToHsl();
                var l = Math.Max(Math.Min((100d - hsl.L) * (factor / 100d), 100d), 0d);

                return new HslColor(hsl.H, hsl.S, l).ToColor();
            };
        }
    }
}
