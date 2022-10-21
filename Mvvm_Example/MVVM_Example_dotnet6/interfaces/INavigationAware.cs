using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example_dotnet6.interfaces
{
    public interface INavigationAware
    {
        void OnNavigating(object sender, object navigationEventArgs);
        void OnNavigated(object sender, object navigationEventArgs);    
    }
}
