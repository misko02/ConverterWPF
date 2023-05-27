using WPFConverter.Models;

namespace WPFConverter.ViewModels;

public class ShellViewModel : Screen
{
    private string _inputVal = String.Empty;
    private string _outputVal = "0";

    private BindableCollection<NumberSystemModel> _systems = new()
    {
        new NumberSystemModel { Name = "Dec", Base = 10, Pattern=new Regex("^[0-9]+$") },
        new NumberSystemModel { Name = "Bin", Base = 2, Pattern= new Regex("^[01]+$") },
        new NumberSystemModel { Name = "Oct", Base = 8,  Pattern=new Regex("^[0-7]+$") },
        new NumberSystemModel { Name = "Hex", Base = 16, Pattern = new Regex("^[0-9A-Fa-f]+$") },
        new NumberSystemModel { Name = "ASCII", Base = 1, Pattern = new Regex("^[\x32-\x7E]+$") }
    };

    private NumberSystemModel _selectedNumberSystemFrom = new() { Name = "Default", Base = 0, Pattern = new Regex("^[\x00-\x7F]+$") };
    private NumberSystemModel _selectedNumberSystemTo = new();
    private Converter? converter = new(String.Empty, 0, 0);

    public ShellViewModel()
    {
        converter = new Converter(InputVal, SelectedNumberSystemFrom.Base, SelectedNumberSystemTo.Base);
    }

    public string InputVal
    {
        get { return _inputVal; }
        set
        {
            if (!string.IsNullOrEmpty(value) && SelectedNumberSystemFrom.Pattern.IsMatch(value))
            {
                _inputVal = value;
                NotifyOfPropertyChange(() => InputVal);
            }
            else
            {
                _inputVal = String.Empty;
                MessageBox.Show($"ERROR OCCURED: Wrong input format", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
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