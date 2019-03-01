using System;
using System.Collections.Generic;
using System.Drawing;

namespace PaletteMixr
{
    public class PaletteGenerator
    {
        private const int hueSpace = 180;
        private readonly Color _baseColor;

        public PaletteGenerator(Color baseColor)
        {
            _baseColor = baseColor;
        }

        public List<Color> GenerateHuePalette(int paletteSize)
        {
            var hueInterval = CalculateHueIntervals(paletteSize);

            var hueShifts = new List<Func<Color, Color>>();

            for(var i = 0; i < paletteSize; i++)
            {
                var shiftDegree = (hueInterval * i) - hueSpace;

                hueShifts.Add(ColorOperations.ShiftHue(shiftDegree));
            }

            return GeneratePalette(hueShifts);
        }

        private double CalculateHueIntervals(int paletteSize)
        {
            return (double)(hueSpace * 2) / paletteSize;
        }

        public List<Color> GeneratePalette(List<Func<Color, Color>> operations)
        {
            var palette = new List<Color>();

            foreach(var operation in operations)
            {
                var result = operation(_baseColor);

                palette.Add(result);
            }

            return palette;
        }
    }
}
