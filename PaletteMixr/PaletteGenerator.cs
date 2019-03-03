using System;
using System.Collections.Generic;
using System.Drawing;

namespace PaletteMixr
{
    public partial class PaletteGenerator
    {
        private readonly Color _baseColor;
        private readonly int _hueSpace;
        private readonly int _saturationRange;
        private readonly int _luminosityRange;

        public PaletteGenerator(
            Color baseColor,
            int hueSpace = 360,
            int saturationRange = 100,
            int luminosityRange = 100)
        {
            _baseColor = baseColor;
            _hueSpace = hueSpace.Clamp(10, 360);
            _saturationRange = saturationRange.Clamp(10, 100);
            _luminosityRange = luminosityRange.Clamp(10, 100);
        }

        public ICollection<Color> GenerateHuePalette(PaletteSize paletteSize)
        {
            Func<double, Func<Color, Color>> operationFn = ColorOperations.ShiftHue;

            return GeneratePaletteType(paletteSize, _hueSpace, operationFn);
        }

        public ICollection<Color> GenerateSaturationPalette(PaletteSize paletteSize)
        {
            Func<double, Func<Color, Color>> operationFn = ColorOperations.AdjustSaturation;

            return GeneratePaletteType(paletteSize, _saturationRange, operationFn);
        }

        public ICollection<Color> GenerateBrightnessPalette(PaletteSize paletteSize)
        {
            Func<double, Func<Color, Color>> operationFn = ColorOperations.AdjustBrightness;

            return GeneratePaletteType(paletteSize, _luminosityRange, operationFn);
        }

        private ICollection<Color> GeneratePaletteType(
            PaletteSize paletteSize,
            int adjustmentRange,
            Func<double, Func<Color, Color>> operationFn)
        {
            var operations = new Func<Color, Color>[(int)paletteSize];

            var adjustmentInterval = (double)adjustmentRange / ((int)paletteSize - 1);

            for (var i = 0; i < (int)paletteSize; i++)
            {
                double adjustment = (adjustmentInterval * i) - ((double)adjustmentRange / 2);

                operations[i] = operationFn(adjustment);
            }

            return GeneratePalette(operations);
        }

        public ICollection<Color> GeneratePalette(params Func<Color, Color>[] operations)
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
