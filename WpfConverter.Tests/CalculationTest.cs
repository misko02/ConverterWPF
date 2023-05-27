namespace WPFConverter.Tests;

public class CalculationTest
{
    private Models.Converter TestsConverter = new Models.Converter("", 0, 0);

    //DECIMAL

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "10")]
    [InlineData("001", "1")]
    [InlineData("010", "10")]
    [InlineData("123", "123")]
    [InlineData("2147483648", "2147483648")]
    public void Conversion_InputIsDec_ReturnsDec(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 10;
        TestsConverter.OutputBase = 10;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "1010")]
    [InlineData("010", "1010")]
    [InlineData("123", "1111011")]
    [InlineData("2147483648", "10000000000000000000000000000000")]
    public void Conversion_InputIsDec_ReturnsBin(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 10;
        TestsConverter.OutputBase = 2;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "12")]
    [InlineData("010", "12")]
    [InlineData("123", "173")]
    [InlineData("2147483648", "20000000000")]
    public void Conversion_InputIsDec_ReturnsOct(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 10;
        TestsConverter.OutputBase = 8;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "A")]
    [InlineData("010", "A")]
    [InlineData("123", "7B")]
    [InlineData("2147483648", "80000000")]
    public void Conversion_InputIsDec_ReturnsHex(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 10;
        TestsConverter.OutputBase = 16;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]                //NOTE: Different test cases, because of specificial type of Ascii
    [InlineData("0", "\0")]
    [InlineData("97", "a")]
    [InlineData("122", "z")]
    [InlineData("097", "a")]
    [InlineData("123", "{")]
    public void Conversion_InputIsDec_ReturnsAscii(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 10;
        TestsConverter.OutputBase = 1;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    //BINARY

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "2")]
    [InlineData("010", "2")]
    [InlineData("1010", "10")]
    [InlineData("10101", "21")]
    [InlineData("10000000000", "1024")]
    public void Conversion_InputIsBin_ReturnsDec(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 2;
        TestsConverter.OutputBase = 10;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "10")]
    [InlineData("010", "10")]
    [InlineData("1010", "1010")]
    [InlineData("10101", "10101")]
    [InlineData("10000000000", "10000000000")]
    public void Conversion_InputIsBin_ReturnsBin(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 2;
        TestsConverter.OutputBase = 2;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "2")]
    [InlineData("010", "2")]
    [InlineData("1010", "12")]
    [InlineData("10101", "25")]
    [InlineData("10000000000", "2000")]
    public void Conversion_InputIsBin_ReturnsOct(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 2;
        TestsConverter.OutputBase = 8;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "2")]
    [InlineData("010", "2")]
    [InlineData("1010", "A")]
    [InlineData("10101", "15")]
    [InlineData("10000000000", "400")]
    public void Conversion_InputIsBin_ReturnsHex(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 2;
        TestsConverter.OutputBase = 16;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "\0")]
    [InlineData("1100001", "a")]
    [InlineData("1111010", "z")]
    [InlineData("01100001", "a")]
    [InlineData("1111011", "{")]
    public void Conversion_InputIsBin_ReturnsAscii(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 2;
        TestsConverter.OutputBase = 1;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    //OCTAL

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "8")]
    [InlineData("010", "8")]
    [InlineData("123", "83")]
    [InlineData("777", "511")]
    public void Conversion_InputIsOct_ReturnsDec(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 8;
        TestsConverter.OutputBase = 10;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "1000")]
    [InlineData("010", "1000")]
    [InlineData("123", "1010011")]
    [InlineData("777", "111111111")]
    public void Conversion_InputIsOct_ReturnsBin(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 8;
        TestsConverter.OutputBase = 2;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "10")]
    [InlineData("010", "10")]
    [InlineData("123", "123")]
    [InlineData("777", "777")]
    public void Conversion_InputIsOct_ReturnsOct(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 8;
        TestsConverter.OutputBase = 8;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "8")]
    [InlineData("010", "8")]
    [InlineData("123", "53")]
    [InlineData("777", "1FF")]
    public void Conversion_InputIsOct_ReturnsHex(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 8;
        TestsConverter.OutputBase = 16;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "\0")]
    [InlineData("141", "a")]
    [InlineData("172", "z")]
    [InlineData("0141", "a")]
    [InlineData("173", "{")]
    public void Conversion_InputIsOct_ReturnsAscii(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 8;
        TestsConverter.OutputBase = 1;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    //HEXADECIMAL

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "16")]
    [InlineData("010", "16")]
    [InlineData("123", "291")]
    [InlineData("2147483648", "142929835592")]
    public void Conversion_InputIsHex_ReturnsDec(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 16;
        TestsConverter.OutputBase = 10;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "10000")]
    [InlineData("010", "10000")]
    [InlineData("123", "100100011")]
    [InlineData("2147483648", "10000101000111010010000011011001001000")]
    public void Conversion_InputIsHex_ReturnsBin(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 16;
        TestsConverter.OutputBase = 2;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "20")]
    [InlineData("010", "20")]
    [InlineData("123", "443")]
    [InlineData("2147483648", "2050722033110")]
    public void Conversion_InputIsHex_ReturnsOct(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 16;
        TestsConverter.OutputBase = 8;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "10")]
    [InlineData("010", "10")]
    [InlineData("123", "123")]
    [InlineData("2147483648", "2147483648")]
    public void Conversion_InputIsHex_ReturnsHex(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 16;
        TestsConverter.OutputBase = 16;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "\0")]
    [InlineData("61", "a")]
    [InlineData("7A", "z")]
    [InlineData("061", "a")]
    [InlineData("7B", "{")]
    public void Conversion_InputIsHex_ReturnsAscii(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 16;
        TestsConverter.OutputBase = 1;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    //ASCII SINGLE CHARACTERS

    [Theory]
    [InlineData("0", "48")]
    [InlineData("1", "49")]
    [InlineData("a", "97")]
    [InlineData("z", "122")]
    [InlineData(".", "46")]
    [InlineData("", "")]
    public void Conversion_InputIsASCII_SingleCharacter_ReturnsDec(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 1;
        TestsConverter.OutputBase = 10;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "110000")]
    [InlineData("1", "110001")]
    [InlineData("a", "1100001")]
    [InlineData("z", "1111010")]
    [InlineData(".", "101110")]
    [InlineData("", "")]
    public void Conversion_InputIsASCII_SingleCharacter_ReturnsBin(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 1;
        TestsConverter.OutputBase = 2;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "60")]
    [InlineData("1", "61")]
    [InlineData("a", "141")]
    [InlineData("z", "172")]
    [InlineData(".", "56")]
    [InlineData("", "")]
    public void Conversion_InputIsASCII_SingleCharacter_ReturnsOct(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 1;
        TestsConverter.OutputBase = 8;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "30")]
    [InlineData("1", "31")]
    [InlineData("a", "61")]
    [InlineData("z", "7A")]
    [InlineData(".", "2E")]
    [InlineData("", "")]
    public void Conversion_InputIsASCII_SingleCharacter_ReturnsHex(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 1;
        TestsConverter.OutputBase = 16;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("a", "a")]
    [InlineData("z", "z")]
    [InlineData(".", ".")]
    [InlineData("", "")]
    public void Conversion_InputIsASCII_SingleCharacter_ReturnsAscii(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 1;
        TestsConverter.OutputBase = 1;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    //ASCII FULL TEXTS
    [Theory]
    [InlineData("0", "48")]
    [InlineData("1", "49")]
    [InlineData("10", "49 48")]
    [InlineData("010", "48 49 48")]
    [InlineData("a", "97")]
    [InlineData("abc", "97 98 99")]
    [InlineData("WPF ascii Converter", "87 80 70 32 97 115 99 105 105 32 67 111 110 118 101 114 116 101 114")]
    public void Conversion_InputIsASCII_FullText_ReturnsDec(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 1;
        TestsConverter.OutputBase = 10;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "110000")]
    [InlineData("1", "110001")]
    [InlineData("10", "110001 110000")]
    [InlineData("010", "110000 110001 110000")]
    [InlineData("a", "1100001")]
    [InlineData("abc", "1100001 1100010 1100011")]
    [InlineData("WPF ascii Converter", "1010111 1010000 1000110 100000 1100001 1110011 1100011 1101001 1101001 100000 1000011 1101111 1101110 1110110 1100101 1110010 1110100 1100101 1110010")]
    public void Conversion_InputIsASCII_FullText_ReturnsBin(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 1;
        TestsConverter.OutputBase = 2;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "60")]
    [InlineData("1", "61")]
    [InlineData("10", "61 60")]
    [InlineData("010", "60 61 60")]
    [InlineData("a", "141")]
    [InlineData("abc", "141 142 143")]
    [InlineData("WPF ascii Converter", "127 120 106 40 141 163 143 151 151 40 103 157 156 166 145 162 164 145 162")]
    public void Conversion_InputIsASCII_FullText_ReturnsOct(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 1;
        TestsConverter.OutputBase = 8;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "30")]
    [InlineData("1", "31")]
    [InlineData("10", "31 30")]
    [InlineData("010", "30 31 30")]
    [InlineData("a", "61")]
    [InlineData("abc", "61 62 63")]
    [InlineData("WPF ascii Converter", "57 50 46 20 61 73 63 69 69 20 43 6F 6E 76 65 72 74 65 72")]
    public void Conversion_InputIsASCII_FullText_ReturnsHex(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 1;
        TestsConverter.OutputBase = 16;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("10", "1 0")]
    [InlineData("010", "0 1 0")]
    [InlineData("a", "a")]
    [InlineData("abc", "a b c")]
    [InlineData("WPF ascii Converter", "W P F   a s c i i   C o n v e r t e r")]
    public void Conversion_InputIsASCII_FullText_ReturnsASCII(string input, string expected)
    {
        //Arrange
        TestsConverter.InputBase = 1;
        TestsConverter.OutputBase = 1;
        TestsConverter.InputVal = input;
        //Act
        var result = TestsConverter.Conversion();
        //Assert
        Assert.Equal(expected, result);
    }
}