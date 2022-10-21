using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MVVM_Example_dotnet6.Base;
using MVVM_Example_dotnet6.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Example_dotnet6.viewmodels
{
    public class CustomViewModel :ViewModelBase
    {
        public ICommand BackCommand { get; set; }
        public CustomViewModel()
        {
            Init();
        }

        private void Init()
        {
            Title = "Customer";
            BackCommand = new RelayCommand(OnBack);
        }

        private void OnBack()
        {
            WeakReferenceMessenger.Default.Send(new NavigationMessage("GoBack"));
        }

        public override void OnNavigated(object sender, object navigationEventArgs)
        {
            Message = "Navigated";
        }
    }
}
