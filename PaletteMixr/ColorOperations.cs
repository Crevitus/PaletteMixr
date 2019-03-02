using System;
using System.Drawing;

namespace PaletteMixr
{
    public static class ColorOperations
    {
        public static Func<Color, Color> Combine(params Func<Color, Color>[] operations)
        {
            return (color) =>
            {
                foreach (var operation in operations)
                {
                    color = operation(color);
                }

                return color;
            };
        }

        public static Func<Color, Color> ShiftHue(double angle)
        {
            return (color) =>
            {
                var hsl = color.ToHsl();

                angle = angle.Clamp(-360d, 360d);
                var h = (hsl.H + (angle / 360d));
                while (h < 0d) h++;
                while (h > 1d) h--;

                return new HslColor(h, hsl.S, hsl.L).ToColor();
            };
        }

        public static Func<Color, Color> AdjustSaturation(double percentage)
        {
            return (color) =>
            {
                var hsl = color.ToHsl();

                var s = AdjustValue(hsl.S, percentage);

                return new HslColor(hsl.H, s, hsl.L).ToColor();
            };
        }

        public static Func<Color, Color> AdjustBrightness(double percentage)
        {
            return (color) =>
            {
                var hsl = color.ToHsl();

                var l = AdjustValue(hsl.L, percentage);

                return new HslColor(hsl.H, hsl.S, l).ToColor();
            };
        }

        private static double AdjustValue(double value, double percentage)
        {
            var adjustedValue = value + (percentage / 100d);

            return adjustedValue.Clamp(0d, 1d);
        }
    }
}
