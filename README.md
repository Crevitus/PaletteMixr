
[![Build status](https://ci.appveyor.com/api/projects/status/2he7gdjww0k64lli/branch/master?svg=true)](https://ci.appveyor.com/project/Crevitus/palettemixr/branch/master)

[![NuGet Version](https://img.shields.io/nuget/vpre/PaletteMixr.svg)](https://www.nuget.org/packages/PaletteMixr)

# PaletteMixr
A library for generating color palettes. Generates a palette of colors based on a single color, providing operations to change the hue, saturation and luminosity.

# Usage

To generate a pallete of colors by shifting the hue simply write:

```csharp

var paletteGenerator = new PaletteGenerator(Color.Blue);
var palette = paletteGenerator.GenerateHuePalette(16);

```

The `PalleteGenerator` takes an instance of the `System.Drawing.Color` struct as the base color for the palette.

The method `GenerateHuePalette(int paletteSize)` takes an `int` that determines the size of the pallet - determining the number of hue degrees to shift when creating the palette.


# Credit

Based upon https://github.com/phjardas/color-palette-generator


# License

[MIT License](LICENSE)
