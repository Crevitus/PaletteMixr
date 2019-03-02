using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;

namespace PaletteMixr.Tests
{
    [TestFixture]
    public partial class SaturationTests
    {
        [Test]
        [TestCaseSource("GetSaturationTestCases")]
        public void ShouldDesaturate_ByFactorSpecified(ColorOperationsTestData testData)
        {
            var saturationAdjustFunc = ColorOperations.AdjustSaturation(testData.Percentange);

            var actual = saturationAdjustFunc(testData.BaseColor);

            Assert.That(actual, Is.EqualTo(testData.ExpectedColor));
        }

        public static IEnumerable<ColorOperationsTestData> GetSaturationTestCases()
        {
            yield return new ColorOperationsTestData
            {
                BaseColor = Color.FromArgb(25, 189, 90), // 77%
                ExpectedColor = Color.FromArgb(36, 178, 92), // 67%
                Percentange = -10,
            };

            yield return new ColorOperationsTestData
            {
                BaseColor = Color.FromArgb(25, 189, 90), // 77%
                ExpectedColor = Color.FromArgb(1, 213, 85), // 99%
                Percentange = 22,
            };

            // Should return same color as Saturation is already 100%
            yield return new ColorOperationsTestData {
                BaseColor = Color.FromArgb(255, 140, 0),
                ExpectedColor = Color.FromArgb(255, 140, 0),
                Percentange = 30,
            };

            yield return new ColorOperationsTestData
            {
                // Should return same color if saturation is already 0
                BaseColor = Color.FromArgb(54, 54, 54),
                ExpectedColor = Color.FromArgb(54, 54, 54),
                Percentange = -1,
            };

            yield return new ColorOperationsTestData
            {
                // Should return return no saturation if saturation goes passed 0, starts at 11
                BaseColor = Color.FromArgb(48, 59, 51),
                ExpectedColor = Color.FromArgb(54, 54, 54),
                Percentange = -11,
            };

            yield return new ColorOperationsTestData
            {
                BaseColor = Color.FromArgb(48, 59, 51),
                ExpectedColor = Color.FromArgb(54, 54, 54),
                Percentange = -11000,
            };

            yield return new ColorOperationsTestData
            {
                BaseColor = Color.FromArgb(48, 59, 51),
                ExpectedColor = Color.FromArgb(0, 107, 29),
                Percentange = 11000,
            };
        }
    }
}
