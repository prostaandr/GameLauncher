using GameLauncher.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace GameLauncher.WPF.Helpers
{
    public class Navigator
    {
        public BaseViewModel CurrentViewModel { get; set; }
        public BaseViewModel SCurrentViewModel { get; set; }

        public EventHandler ChangeViewModel;

        public void ChangeViewModelHandler(BaseViewModel vm)
        {
            var handler = ChangeViewModel;
            CurrentViewModel = vm;
            handler?.Invoke(this, EventArgs.Empty);
        }

    }
}
