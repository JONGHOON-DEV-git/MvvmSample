using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_Example_dotnet6.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example_dotnet6.Base
{
    public class ViewModelBase : ObservableObject, INavigationAware
    {

        

        private string? _title;
        public string Title
        {
            get { return _title?? ""; }
            set { SetProperty(ref _title, value); }
        }

        private string? _message;
        public string? Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        
        public virtual void OnNavigating(object sender, object navigationEventArgs)
        {
            
        }

        public virtual void OnNavigated(object sender, object navigationEventArgs)
        {
            
        }
    }
}
