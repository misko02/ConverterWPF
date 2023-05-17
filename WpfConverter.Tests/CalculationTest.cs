namespace WPFConverter.Tests;

public class CalculationTest
{
    [Fact]
    public void Conversion_FromDec_ToAny()
    {
        var exampleInput = "100";
        var initialBase = 10;
        var converterToDec = new Models.Converter(exampleInput, initialBase, 10);
        var converterToBin = new Models.Converter(exampleInput, initialBase, 2);
        var converterToOct = new Models.Converter(exampleInput, initialBase, 8);
        var converterToHex = new Models.Converter(exampleInput, initialBase, 16);
        var converterToAscii = new Models.Converter(exampleInput, initialBase, 1);

        Assert.Equal("100", converterToDec.Conversion());
        Assert.Equal("1100100", converterToBin.Conversion());
        Assert.Equal("144", converterToOct.Conversion());
        Assert.Equal("64", converterToHex.Conversion());
        Assert.Equal("d", converterToAscii.Conversion());
    }

    [Fact]
    public void Conversion_FromBin_ToAny()
    {
        var exampleInput = "1100100";
        var initialBase = 2;

        var converterToDec = new Models.Converter(exampleInput, initialBase, 10);
        var converterToBin = new Models.Converter(exampleInput, initialBase, 2);
        var converterToOct = new Models.Converter(exampleInput, initialBase, 8);
        var converterToHex = new Models.Converter(exampleInput, initialBase, 16);
        var converterToAscii = new Models.Converter(exampleInput, initialBase, 1);

        Assert.Equal("100", converterToDec.Conversion());
        Assert.Equal("1100100", converterToBin.Conversion());
        Assert.Equal("144", converterToOct.Conversion());
        Assert.Equal("64", converterToHex.Conversion());
        Assert.Equal("d", converterToAscii.Conversion());
    }

    [Fact]
    public void Conversion_FromOct_ToAny()
    {
        var exampleInput = "144";
        var initialBase = 8;

        var converterToDec = new Models.Converter(exampleInput, initialBase, 10);
        var converterToBin = new Models.Converter(exampleInput, initialBase, 2);
        var converterToOct = new Models.Converter(exampleInput, initialBase, 8);
        var converterToHex = new Models.Converter(exampleInput, initialBase, 16);
        var converterToAscii = new Models.Converter(exampleInput, initialBase, 1);

        Assert.Equal("100", converterToDec.Conversion());
        Assert.Equal("1100100", converterToBin.Conversion());
        Assert.Equal("144", converterToOct.Conversion());
        Assert.Equal("64", converterToHex.Conversion());
        Assert.Equal("d", converterToAscii.Conversion());
    }

    [Fact]
    public void Conversion_FromHex_ToAny()
    {
        var exampleInput = "64";
        var initialBase = 16;

        var converterToDec = new Models.Converter(exampleInput, initialBase, 10);
        var converterToBin = new Models.Converter(exampleInput, initialBase, 2);
        var converterToOct = new Models.Converter(exampleInput, initialBase, 8);
        var converterToHex = new Models.Converter(exampleInput, initialBase, 16);
        var converterToAscii = new Models.Converter(exampleInput, initialBase, 1);

        Assert.Equal("100", converterToDec.Conversion());
        Assert.Equal("1100100", converterToBin.Conversion());
        Assert.Equal("144", converterToOct.Conversion());
        Assert.Equal("64", converterToHex.Conversion());
        Assert.Equal("d", converterToAscii.Conversion());
    }

    [Fact]
    public void Conversion_FromASCII_SingleCharacter_ToAny()
    {
        var exampleInput = "d";
        var initialBase = 1;

        var converterToDec = new Models.Converter(exampleInput, initialBase, 10);
        var converterToBin = new Models.Converter(exampleInput, initialBase, 2);
        var converterToOct = new Models.Converter(exampleInput, initialBase, 8);
        var converterToHex = new Models.Converter(exampleInput, initialBase, 16);
        var converterToAscii = new Models.Converter(exampleInput, initialBase, 1);

        Assert.Equal("100", converterToDec.Conversion());
        Assert.Equal("1100100", converterToBin.Conversion());
        Assert.Equal("144", converterToOct.Conversion());
        Assert.Equal("64", converterToHex.Conversion());
        Assert.Equal("d", converterToAscii.Conversion());
    }
}