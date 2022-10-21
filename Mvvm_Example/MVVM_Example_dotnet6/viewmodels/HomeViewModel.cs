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
    public class HomeViewModel :ViewModelBase
    {
        public static int Count { get; set; }

        public ICommand BusyTestCommand { get; set; }
        public HomeViewModel()
        {
            Title = "Home";

            Init();
        }

        private void Init()
        {
            BusyTestCommand = new AsyncRelayCommand(OnBusyTestAsync);
        }


        public override void OnNavigated(object sender, object navigationEventArgs)
        {
            Count++;
            Message = $"{Count} Navigated";
        }

        public async Task OnBusyTestAsync()
        {
            WeakReferenceMessenger.Default.Send(new BusyMessage(true) { BusyId = "OnBusyTestAsync" });
            await Task.Delay(5000);
            WeakReferenceMessenger.Default.Send(new BusyMessage(false) { BusyId = "OnBusyTestAsync" });
        }
    }
}
