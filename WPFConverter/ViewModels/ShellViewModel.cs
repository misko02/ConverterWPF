using WPFConverter.Models;

namespace WPFConverter.ViewModels;

public class ShellViewModel : Screen
{
    private string _inputVal = String.Empty;
    private string _outputVal = "0";
    private BindableCollection<NumberSystemModel> _systems = new();
    private NumberSystemModel _selectedNumberSystemFrom = new();
    private NumberSystemModel _selectedNumberSystemTo = new();
    private Converter? converter = new(String.Empty, 0, 0);

    public ShellViewModel()
    {
        Systems.Add(new NumberSystemModel { Name = "Dec", Base = 10 });
        Systems.Add(new NumberSystemModel { Name = "Bin", Base = 2 });
        Systems.Add(new NumberSystemModel { Name = "Oct", Base = 8 });						//Demo Data
        Systems.Add(new NumberSystemModel { Name = "Hex", Base = 16 });
        Systems.Add(new NumberSystemModel { Name = "ASCII", Base = 1 });
        converter = new Converter(InputVal, SelectedNumberSystemFrom.Base, SelectedNumberSystemTo.Base);
    }

    public string InputVal
    {
        get { return _inputVal; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _inputVal = value;
                NotifyOfPropertyChange(() => InputVal);
            }
        }
    }

    public string OutputVal
    {
        get { return _outputVal; }
        set
        {
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
        get
        {
            return _selectedNumberSystemFrom;
        }
        set
        {
            if (value != null)
            {
                _selectedNumberSystemFrom = value;
                NotifyOfPropertyChange(() => SelectedNumberSystemFrom);
            }
        }
    }

    public NumberSystemModel SelectedNumberSystemTo
    {
        get
        {
            return _selectedNumberSystemTo;
        }
        set
        {
            if (value != null)
            {
                _selectedNumberSystemTo = value;
                NotifyOfPropertyChange(() => SelectedNumberSystemTo);
            }
        }
    }

    //Events???

    public void EnterPressedDown(KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            Submit();
        }
    }

    public void Submit()
    {
        try
        {
            converter.InputVal = _inputVal;
            converter.InputBase = _selectedNumberSystemFrom.Base;
            converter.OutputBase = _selectedNumberSystemTo.Base;
            OutputVal = converter.Conversion();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"ERROR OCCURED: {ex.Message}", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}