
[![Build status](https://ci.appveyor.com/api/projects/status/2he7gdjww0k64lli/branch/master?svg=true)](https://ci.appveyor.com/project/Crevitus/palettemixr/branch/master)

[![NuGet Version](https://img.shields.io/nuget/vpre/PaletteMixr.svg)](https://www.nuget.org/packages/PaletteMixr)

# PaletteMixr
A library for generating color palettes. Generates a palette of colors based on a single color, providing operations to change the hue, saturation and luminosity.

# Usage

## Basic Usage

To generate a palette of colors by shifting the hue simply write:

```csharp

var paletteGenerator = new PaletteGenerator(Color.Blue);
var palette = paletteGenerator.GenerateHuePalette(PaletteSize.Small);

```

The `PalleteGenerator` takes an instance of the `System.Drawing.Color` struct as the base color for the palette.

The method `GenerateHuePalette(PaletteSize paletteSize)` takes a `PaletteSize` enum that determines the size of the pallet - determining the number of hue degrees to shift when creating the palette.

## Advanced

For a more custom palette, the `PaletteGenerator` can be used to generate any number of colors by passing in color operations, each one adjusting the base color and adding the result to color palette collection that is returned:

```csharp

using static PaletteMixr.ColorOperations;
...

var paletteGenerator = new PaletteGenerator(Color.Blue);

paletteGenerator.GeneratePalette(
                ShiftHue(30),
                AdjustSaturation(-10)
                );
```


To combine color operations together to create 1 palette color you can use the `Combine` function:

```csharp
paletteGenerator.GeneratePalette(
    ShiftHue(30),
    Combine(
        ShiftHue(10),
        AdjustSaturation(50)
    ));
```

# Credit

Based upon https://github.com/phjardas/color-palette-generator


# License

[MIT License](LICENSE)
