using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFConverter.Models;

namespace WPFConverter.ViewModels
{
    public class ShellViewModel:Screen
    {
		private string _inputVal="";
		private string _outputVal="0";
		private BindableCollection<NumberSystemModel> _systems = new();
		private NumberSystemModel _selectedNumberSystemFrom;
		private NumberSystemModel _selectedNumberSystemTo;

		public ShellViewModel()
		{
            Systems.Add(new NumberSystemModel{Name="Dec", Base=10});
            Systems.Add(new NumberSystemModel{Name="Bin", Base=2});
            Systems.Add(new NumberSystemModel{Name="Oct", Base=8});						//Demo Data
            Systems.Add(new NumberSystemModel{Name="Hex", Base=16});
            Systems.Add(new NumberSystemModel{Name="ASCII", Base=1});
        }

		public string InputVal
		{
			get { return _inputVal; }
			set { 
				_inputVal = value;
				NotifyOfPropertyChange(() => InputVal);
			}
		}
		public string OutputVal
		{
			get { return _outputVal; }
			set { 
				_outputVal = value;
				NotifyOfPropertyChange(() => OutputVal);
			}
		}
		public BindableCollection<NumberSystemModel> Systems
		{
			get { return _systems; }
			set { _systems = value; }
		}
        public NumberSystemModel SelectedNumberSystemFrom
		{
			get { return _selectedNumberSystemFrom; }
			set { 
				_selectedNumberSystemFrom = value;
				NotifyOfPropertyChange(()=>SelectedNumberSystemFrom);
			}
		}
        public NumberSystemModel SelectedNumberSystemTo
        {
            get { return _selectedNumberSystemTo; }
            set
            {
                _selectedNumberSystemTo = value;
                NotifyOfPropertyChange(() => SelectedNumberSystemTo);
            }
        }

		//Events???
		

		public void Submit()
		{
			if (SelectedNumberSystemTo != null && SelectedNumberSystemFrom != null && !string.IsNullOrEmpty(InputVal))
			{
				var converter = new Converter(InputVal, SelectedNumberSystemFrom.Base, SelectedNumberSystemTo.Base);
				OutputVal = converter.Convertion();
			}
		}

    }

}
