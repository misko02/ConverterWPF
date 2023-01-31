namespace WPFConverter.Models
{
    public class Converter
    {
		private string _inputVal;
		private int _inputBase;
		private int  _outputBase;

        public string InputVal {
			get
			{
				return _inputVal;
			}
			set
			{
				_inputVal = value;
			}
		}
		public int InputBase { 
			get 
			{
				return _inputBase;
			}
			set
			{
				_inputBase = value;
			}
		}
		public int OutputBase {
			get
			{
				return _outputBase;
			}
			set
			{
				_outputBase = value;
			}
		}

        public Converter(string inputVal,int inputBase,int outputBase)
		{
			this._inputBase = inputBase;
			this._outputBase = outputBase;
			this._inputVal = inputVal;
		}

		/// <summary>
		/// Function which takes input value, input base and output base, then convert its input to it's version in given ouput base
		/// </summary>
		/// <returns>string format of converted by a specified base system input</returns>

		public string Convertion()
		{
			string result = "";

			switch (InputBase)
			{
				case 1:result = AsciiConvertion();break;
				case 2: case 8: case 16:result = NumericalBasedConvertion();break;
				case 10:result = DecConvertion();break;
				default:break;
			}
			

			return result; 
		}

		private string AsciiConvertion()
		{
			var input = _inputVal;
			var numbers=new List<string>();
			foreach(char letter in input)
			{
				_inputVal = Convert.ToString((int)letter);

				numbers.Add($"{DecConvertion()} ");
			}

			return string.Concat(numbers).Trim();
		}
		private string NumericalBasedConvertion()
		{
			if (_outputBase == 1)
			{
				string resultASCII = "";
				var numbers = _inputVal.Split(" ");
				var numberAsDec="";
				foreach (var number in numbers)
				{
					_inputVal = number;
					_outputBase = 10;
					numberAsDec = NumericalBasedConvertion();			//???
					_inputVal= numberAsDec;
					_outputBase = 1;
					resultASCII += DecConvertion();
				}
				return resultASCII;
			}
			else
			{
				var result = 0d;
				for (int i = _inputVal.Length - 1; i >= 0; i--)
				{

					int digit;
					int.TryParse(Convert.ToString(_inputVal[i]),out digit);
					
					result += digit * Math.Pow(_inputBase, _inputVal.Length - 1 - i);
				}
				_inputVal = Convert.ToString(result);
				return DecConvertion();
			}
		}
		private string DecConvertion() 
		{
			string result = "";
			
			if (_outputBase == 1)			//converting to ASCII
			{
				var words = _inputVal.Trim().Split(' ');
				foreach (var word in words)
				{
					result += (char)(Convert.ToInt32(word));
				}

			}
			else if (_inputVal=="0")
			{
				return "0";
			}
			else
			{
				int value = Convert.ToInt32(_inputVal);
				int convertedDigit = 0;
				while (value > 0)
				{
					convertedDigit = (value % _outputBase);
					if (convertedDigit >= 10)
					{
						result += (char)(55 + convertedDigit);
					}
					else
					{
						result += convertedDigit;
					}
					value /= _outputBase;
				}
                char[] resultArray = result.ToCharArray();
                Array.Reverse(resultArray);
				result = new string(resultArray);
            }
			return result;
        }

    }
}