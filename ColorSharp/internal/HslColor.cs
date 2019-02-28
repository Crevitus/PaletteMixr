using System;
using System.Drawing;

namespace ColorSharp
{
    internal struct HslColor
    {
        public HslColor(double h, double s, double l)
        {
            H = h;
            S = s;
            L = l;
        }

        public double H { get; }
        public double S { get; }
        public double L { get; }

        public Color ToColor()
        {
            double r, g, b;

            if (S == 0)
            {
                r = g = b = L;
            }
            else
            {
                double temp1;
                if (L < 0.5d)
                {
                    temp1 = L * (1d + S);
                }
                else
                {
                    temp1 = L + S - (L * S);
                }

                double temp2 = (2d * L) - temp1;

                r = ConvertColorPart(temp1, temp2, H + (1d / 3d));
                g = ConvertColorPart(temp1, temp2, H);
                b = ConvertColorPart(temp1, temp2, H - (1d / 3d));
            }


            r = Math.Round(r * 255d);
            g = Math.Round(g * 255d);
            b = Math.Round(b * 255d);

            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        private double ConvertColorPart(double temp1, double temp2, double hue)
        {
            if (hue < 0d)
            {
                hue++;
            }
            else if (hue > 1d)
            {
                hue--;
            }

            if (hue < 1d / 6d)
            {
                return temp2 + ((temp1 - temp2) * 6d * hue);
            }
            else if (hue < 1d / 2d)
            {
                return temp1;
            }
            else if (hue < 2d / 3d)
            {
                return temp2 + ((temp1 - temp2) * ((2d / 3d) - hue) * 6d);
            }

            return temp2;
        }
    }
}
