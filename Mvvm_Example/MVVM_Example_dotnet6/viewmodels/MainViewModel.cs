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
            WeakReferenceMessenger.Default.Register<BusyMessage>(this, OnBusyMessage);
            WeakReferenceMessenger.Default.Register<LayerPopupMessage>(this, OnLayerPopupMessage);
        }

        private void OnNavigationMessage(object recipient, NavigationMessage message)
        {
            NavigationSource = message.Value;
        }

        private void OnNavigate(string? pageUri)
        {
            NavigationSource = pageUri;
        }

        private IList<BusyMessage> _busys = new List<BusyMessage>();

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                SetProperty(ref _isBusy, value);
            }
        }
        
        private void OnBusyMessage(object recipient, BusyMessage message)
        {
            if(message.Value)
            {
                var existBusy = _busys.FirstOrDefault(x => x.BusyId == message.BusyId);
                if(existBusy != null)
                {
                    return;
                }
                _busys.Add(message);
            }
            else
            {
                var existBusy = _busys.FirstOrDefault(x => x.BusyId == message.BusyId);
                if(existBusy == null)
                {
                    return;
                }
                _busys.Remove(existBusy);
            }
            IsBusy = _busys.Any();
        }

        private bool _showLayerPopup;

        public bool ShowLayerPopup
        {
            get
            {
                return _showLayerPopup;
            }
            set
            {
                SetProperty(ref _showLayerPopup, value);
            }
        }

        private string _controlName;
        public string ControlName
        {
            get
            {
                return _controlName;
            }
            set
            {
                SetProperty(ref _controlName, value);
            }
        }

        private  void OnLayerPopupMessage(object recipient, LayerPopupMessage message)
        {
            ShowLayerPopup = message.Value;
            ControlName = message.ControlName;
        }
        
    }
}
