using NUnit.Framework;
using System.Drawing;
using static PaletteMixr.ColorOperations;

namespace PaletteMixr.Tests
{
    public class PaletteGeneratorTests
    {
        [Test]
        public void ShouldGenerate_FullHueRange()
        {
            var test = Color.Green;

            var testGen = new PaletteGenerator(test, hueSpace: 89);

            var results = testGen.GenerateSaturationPalette(PaletteSize.XLarge);

            testGen.GeneratePalette(
                ShiftHue(30),
                Combine(
                    ShiftHue(30),
                    AdjustSaturation(50)
                ));
        }
    }
}
