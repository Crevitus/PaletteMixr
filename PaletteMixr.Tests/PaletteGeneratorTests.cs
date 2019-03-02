using NUnit.Framework;
using System.Drawing;
using static PaletteMixr.ColorOperations;

namespace PaletteMixr.Tests
{
    public class PaletteGeneratorTests
    {
        [Test]
        public void TestMethod1()
        {
            var test = Color.Green;

            var testGen = new PaletteGenerator(test);

            var results = testGen.GenerateHuePalette(16);

            testGen.GeneratePalette(
                ShiftHue(30),
                Combine(
                    ShiftHue(30),
                    AdjustSaturation(50)
                ));
        }
    }
}
