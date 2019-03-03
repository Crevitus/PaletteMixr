using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace PaletteMixr.Tests
{
    [TestFixture]
    public class HueShiftTests
    {
        [Test]
        [TestCaseSource("GetShiftHueTestCases")]
        public void ShouldShiftHue_ByAngleSpecified(ShiftHueTestData testData)
        {
            var hueFunc = ColorOperations.ShiftHue(testData.Angle);

            var actual = hueFunc(testData.BaseColor);

            Assert.That(actual, Is.EqualTo(testData.ExpectedColor));
        }

        public static IEnumerable<ShiftHueTestData> GetShiftHueTestCases()
        {
            yield return new ShiftHueTestData {
                BaseColor = Color.FromArgb(255, 140, 0), // Dark Orange 33% Hue
                ExpectedColor = Color.FromArgb(242, 255, 0), // Light Yellow 63% Hue
                Angle = 30,
            };

            yield return new ShiftHueTestData
            {
                BaseColor = Color.FromArgb(255, 140, 0), // Dark Orange 33% Hue
                ExpectedColor = Color.FromArgb(255, 140, 0),
                Angle = 0,
            };

            yield return new ShiftHueTestData
            {
                // Hue Shifting white shoud result in white only
                BaseColor = Color.FromArgb(255, 255, 255),
                ExpectedColor = Color.FromArgb(255, 255, 255),
                Angle = 50,
            };

            yield return new ShiftHueTestData
            {
                // Hue Shifting white shoud result in white only
                BaseColor = Color.FromArgb(255, 255, 255),
                ExpectedColor = Color.FromArgb(255, 255, 255),
                Angle = -40,
            };

            yield return new ShiftHueTestData
            {
                // Hue Shifting black shoud result in black only
                BaseColor = Color.FromArgb(0, 0, 0),
                ExpectedColor = Color.FromArgb(0, 0, 0),
                Angle = 60,
            };

            yield return new ShiftHueTestData
            {
                // Hue Shifting black shoud result in black only
                BaseColor = Color.FromArgb(0, 0, 0),
                ExpectedColor = Color.FromArgb(0, 0, 0),
                Angle = 20,
            };

            yield return new ShiftHueTestData
            {
                BaseColor = Color.FromArgb(24, 56, 0),
                ExpectedColor = Color.FromArgb(24, 56, 0),
                Angle = 360,
            };

            yield return new ShiftHueTestData
            {
                BaseColor = Color.FromArgb(24, 56, 0),
                ExpectedColor = Color.FromArgb(24, 56, 0),
                Angle = -360,
            };

            yield return new ShiftHueTestData
            {
                BaseColor = Color.FromArgb(24, 56, 0),
                ExpectedColor = Color.FromArgb(24, 56, 0),
                Angle = -36000,
            };

            yield return new ShiftHueTestData
            {
                BaseColor = Color.FromArgb(24, 56, 0),
                ExpectedColor = Color.FromArgb(24, 56, 0),
                Angle = 36000,
            };
        }

        public class ShiftHueTestData
        {
            public Color BaseColor { get; set; }
            public Color ExpectedColor { get; set; }
            public double Angle { get; set; }
        }
    }
}
