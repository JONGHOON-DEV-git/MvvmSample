using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_Example_dotnet6.Base;

namespace MVVM_Example_dotnet6.viewmodels
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.Title = "Main View";
        }
    }
}
