using System;
using System.Drawing;
using Xunit;

namespace PaletteMixr.Tests
{
    public class PaletteGeneratorTests
    {
        [Fact]
        public void TestMethod1()
        {
            var test = Color.Green;

            var testGen = new PaletteGenerator(test);

            var results = testGen.GenerateHuePalette(16);
        }
    }
}
