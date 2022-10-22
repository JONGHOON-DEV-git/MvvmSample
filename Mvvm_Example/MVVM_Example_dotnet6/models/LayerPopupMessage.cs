using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example_dotnet6.models
{
    public class LayerPopupMessage :ValueChangedMessage<bool>
    {
        public string ControlName { get; set; }

        public object Parameter { get; set; } = null;
        public LayerPopupMessage(bool value) :base(value)
        {

        }
    }
}
