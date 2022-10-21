﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example_dotnet6.Base
{
    public class ViewModelBase : ObservableObject
    {
        private string? _title;
        public string Title
        {
            get { return _title?? ""; }
            set { SetProperty(ref _title, value); }
        }
    }
}
