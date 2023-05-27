namespace WPFConverter.Models;

public class Converter
{
    public string InputVal
    {
        get; set;
    }

    public int InputBase
    {
        get; set;
    }

    public int OutputBase
    {
        get; set;
    }

    public Converter(string inputVal, int inputBase, int outputBase)
    {
        this.InputVal = inputVal;
        this.InputBase = inputBase;
        this.OutputBase = outputBase;
    }

    /// <summary>
    /// Function which takes input value, input base and output base, then convert its input to it's version in given ouput base
    /// </summary>
    /// <returns>string format of converted by a specified base system input</returns>

    public string Conversion()
    {
        string result = String.Empty;

        switch (InputBase)
        {
            case 1: result = AsciiConversion(); break;
            case 2: case 8: case 16: result = NumericalBasedConversion(); break;
            case 10: result = DecConversion(); break;
            default: break;
        }

        return result;
    }

    private string AsciiConversion()
    {
        var input = InputVal;
        var numbers = new List<string>();
        foreach (char letter in input)
        {
            InputVal = Convert.ToString((int)letter);
            numbers.Add($"{DecConversion()} ");
        }

        return string.Concat(numbers).Trim();
    }

    private string NumericalBasedConversion()
    {
        if (OutputBase == 1)
        {
            string resultAsAscii = String.Empty;
            var numbers = InputVal.Split(" ");
            var numberAsDec = String.Empty;
            foreach (var number in numbers)
            {
                InputVal = number;
                OutputBase = 10;
                numberAsDec = NumericalBasedConversion();           //???
                InputVal = numberAsDec;
                OutputBase = 1;
                resultAsAscii += DecConversion();
            }
            return resultAsAscii;
        }
        else
        {
            var result = 0d;
            for (int i = InputVal.Length - 1; i >= 0; i--)
            {
                char currentCharacter = InputVal[i];
                int digit;
                if (Char.IsLetter(currentCharacter))
                {
                    digit = ((int)currentCharacter) - 55;
                }
                else
                {
                    int.TryParse(Convert.ToString(currentCharacter), out digit);
                }
                result += digit * Math.Pow(InputBase, InputVal.Length - 1 - i);
            }
            InputVal = Convert.ToString(result);
            return DecConversion();
        }
    }

    private string DecConversion()
    {
        string result = String.Empty;

        if (OutputBase == 1)           //converting to ASCII
        {
            var words = InputVal.Trim().Split(' ');
            foreach (var word in words)
            {
                result += (char)(Convert.ToInt32(word));
            }
        }
        else if (InputVal == "0")
        {
            return "0";
        }
        else
        {
            var value = Convert.ToInt64(InputVal);
            var convertedDigit = 0L;
            while (value > 0)
            {
                convertedDigit = (value % OutputBase);
                if (convertedDigit >= 10)
                {
                    result += (char)(55 + convertedDigit);
                }
                else
                {
                    result += convertedDigit;
                }
                value /= OutputBase;
            }
            char[] resultArray = result.ToCharArray();
            Array.Reverse(resultArray);
            result = new string(resultArray);
        }
        return result;
    }
}