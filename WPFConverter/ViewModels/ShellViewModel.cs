using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFConverter.ViewModels
{
    public class ShellViewModel:Screen
    {
		private string _inputVal="";

		public string InputVal
		{
			get { return _inputVal; }
			set { _inputVal = value; }
		}

		private string _outputVal="0";

		public string OutputVal
		{
			get { return _outputVal; }
			set { _outputVal = value; }
		}


	}

}
