using NUnit.Framework;
using System.Drawing;

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
        }
    }
}
