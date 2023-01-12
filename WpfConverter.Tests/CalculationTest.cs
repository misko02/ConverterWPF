namespace WPFConverter.Tests
{
    public class CalculationTest
    {
        [Fact]
        public void Convertion_FromDec_ToAny()
        {
            var exampleInput = "100";
            var initialBase = 10;
            var converterToDec = new Models.Converter(exampleInput,initialBase,10);
            var converterToBin = new Models.Converter(exampleInput, initialBase, 2);
            var converterToOct = new Models.Converter(exampleInput, initialBase, 8);
            var converterToHex = new Models.Converter(exampleInput, initialBase, 16);
            var converterToAscii = new Models.Converter(exampleInput, initialBase, 1);

            Assert.Equal("100", converterToDec.Convertion());
            Assert.Equal("1100100", converterToBin.Convertion());
            Assert.Equal("144", converterToOct.Convertion());
            Assert.Equal("64", converterToHex.Convertion());
            Assert.Equal("d",converterToAscii.Convertion());
        }
        [Fact]
        public void Convertion_FromBin_ToAny()
        {
            var exampleInput = "1100100";
            var initialBase = 2;

            var converterToDec = new Models.Converter(exampleInput, initialBase, 10);
            var converterToBin = new Models.Converter(exampleInput, initialBase, 2);
            var converterToOct = new Models.Converter(exampleInput, initialBase, 8);
            var converterToHex = new Models.Converter(exampleInput, initialBase, 16);
            var converterToAscii = new Models.Converter(exampleInput, initialBase, 1);

            Assert.Equal("100", converterToDec.Convertion());
            Assert.Equal("1100100", converterToBin.Convertion());
            Assert.Equal("144", converterToOct.Convertion());
            Assert.Equal("64", converterToHex.Convertion());
            Assert.Equal("d", converterToAscii.Convertion());
        }
        [Fact]
        public void Convertion_FromOct_ToAny()
        {
            var exampleInput = "144";
            var initialBase = 8;

            var converterToDec = new Models.Converter(exampleInput, initialBase, 10);
            var converterToBin = new Models.Converter(exampleInput, initialBase, 2);
            var converterToOct = new Models.Converter(exampleInput, initialBase, 8);
            var converterToHex = new Models.Converter(exampleInput, initialBase, 16);
            var converterToAscii = new Models.Converter(exampleInput, initialBase, 1);

            Assert.Equal("100", converterToDec.Convertion());
            Assert.Equal("1100100", converterToBin.Convertion());
            Assert.Equal("144", converterToOct.Convertion());
            Assert.Equal("64", converterToHex.Convertion());
            Assert.Equal("d", converterToAscii.Convertion());
        }
        [Fact]
        public void Convertion_FromHex_ToAny()
        {
            var exampleInput = "64";
            var initialBase = 16;

            var converterToDec = new Models.Converter(exampleInput, initialBase, 10);
            var converterToBin = new Models.Converter(exampleInput, initialBase, 2);
            var converterToOct = new Models.Converter(exampleInput, initialBase, 8);
            var converterToHex = new Models.Converter(exampleInput, initialBase, 16);
            var converterToAscii = new Models.Converter(exampleInput, initialBase, 1);

            Assert.Equal("100", converterToDec.Convertion());
            Assert.Equal("1100100", converterToBin.Convertion());
            Assert.Equal("144", converterToOct.Convertion());
            Assert.Equal("64", converterToHex.Convertion());
            Assert.Equal("d", converterToAscii.Convertion());
        }
        [Fact]
        public void Convertion_FromASCII_SingleCharacter_ToAny()
        {
            var exampleInput = "d";
            var initialBase = 1;

            var converterToDec = new Models.Converter(exampleInput, initialBase, 10);
            var converterToBin = new Models.Converter(exampleInput, initialBase, 2);
            var converterToOct = new Models.Converter(exampleInput, initialBase, 8);
            var converterToHex = new Models.Converter(exampleInput, initialBase, 16);
            var converterToAscii = new Models.Converter(exampleInput, initialBase, 1);

            Assert.Equal("100", converterToDec.Convertion());
            Assert.Equal("1100100", converterToBin.Convertion());
            Assert.Equal("144", converterToOct.Convertion());
            Assert.Equal("64", converterToHex.Convertion());
            Assert.Equal("d", converterToAscii.Convertion());
        }
    }
}