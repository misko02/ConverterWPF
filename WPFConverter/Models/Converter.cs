using Caliburn.Micro;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFConverter.Models
{
    internal class Converter
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

		public string Convertion()
		{
			int value = Convert.ToInt32(_inputVal);
			string result = "";
			if (_inputBase== 10)
			{
				result = DecConvertion(value);
			}
			char[] resultArray = result.ToCharArray();
			Array.Reverse(resultArray);

			return new string(resultArray); 
		}
		private string DecConvertion(int value)
		{
            int convertedDigit = 0;
			string convertedNumber = "";
            while (value > 0)
            {
                convertedDigit = (value % _outputBase);
                if (convertedDigit >= 10)
				{
                    convertedNumber += (char)(54 + convertedDigit);
                }
                else
				{
                    convertedNumber += convertedDigit;
                }
                value /= _outputBase;
            }
			return convertedNumber;
        }

    }
}