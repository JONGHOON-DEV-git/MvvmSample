using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MVVM_Example_dotnet6.Base;
using MVVM_Example_dotnet6.models;

namespace MVVM_Example_dotnet6.viewmodels
{
    internal class MainViewModel : ViewModelBase
    {
        private string? _navigationSource;
        public string? NavigationSource
        {
            get { return _navigationSource; }
            set { SetProperty(ref _navigationSource, value); }
        }

        public ICommand NavigateCommand { get; set; }

        public MainViewModel()
        {
            this.Title = "Main View";
            Init();
        }

        private void Init()
        {
            NavigationSource = "/Views/HomePage.xaml";
            NavigateCommand = new RelayCommand<String>(OnNavigate);

            WeakReferenceMessenger.Default.Register<NavigationMessage>(this, OnNavigationMessage);
        }

        private void OnNavigationMessage(object recipient, NavigationMessage message)
        {
            NavigationSource = message.Value;
        }

        private void OnNavigate(string? pageUri)
        {
            NavigationSource = pageUri;

        }
    }
}
