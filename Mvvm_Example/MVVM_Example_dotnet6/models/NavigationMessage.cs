using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MVVM_Example_dotnet6.models
{
    internal class NavigationMessage :ValueChangedMessage<string>
    {
        public NavigationMessage(string value ):base(value)
        {

        }
    }
}