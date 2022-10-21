using MVVM_Example_dotnet6.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example_dotnet6.viewmodels
{
    public class HomeViewModel :ViewModelBase
    {
        public static int Count { get; set; }
        public HomeViewModel()
        {
            Title = "Home";
        }

        public override void OnNavigated(object sender, object navigationEventArgs)
        {
            Count++;
            Message = $"{Count} Navigated";
        }
    }
}
