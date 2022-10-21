using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm_Example
{
    public class mvvmbase : ObservableObject
    {
        public ObservableCollection<Model> models { get; set; }

        public mvvmbase()
        {
            models = new ObservableCollection<Model>();
            models.Add(new Model() { ModelName="Model1", ModelNO=1 });
            models.Add(new Model() { ModelName = "Model2", ModelNO = 2 });
            models.Add(new Model() { ModelName = "Model3", ModelNO = 3 });
            models.Add(new Model() { ModelName = "Model4", ModelNO = 4 });
            models.Add(new Model() { ModelName = "Model5", ModelNO = 5 });
            models.Add(new Model() { ModelName = "Model6", ModelNO = 6 });
        }

    }
}
