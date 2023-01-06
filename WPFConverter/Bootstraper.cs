using WPFConverter.Models;
using WPFConverter.ViewModels;

namespace WPFConverter
{
    public class Bootstraper : BootstrapperBase
    {
        public Bootstraper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<ShellViewModel>();
            
        }
    }
}
