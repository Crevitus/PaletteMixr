using System.Drawing;

namespace PaletteMixr.Tests
{
    public partial class SaturationTests
    {
        public class ColorOperationsTestData
        {
            public Color BaseColor { get; set; }
            public Color ExpectedColor { get; set; }
            public int Percentange { get; set; }
        }
    }
}
