using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MVVM_Example_dotnet6.interfaces;

namespace MVVM_Example_dotnet6.behavior
{
    public class FrameBehavior : Behavior<Frame>
    {
        private bool _isWork;
        public string NavigationSource
        {
            get { return (string)GetValue(NavigationSourceProperty); }
            set { SetValue(NavigationSourceProperty, value); }
        }

        
        protected override void OnAttached()
        {
            AssociatedObject.Navigating += AssociatedObject_Navigating;
            AssociatedObject.Navigated += AssociatedObject_Navigated;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Navigating -= AssociatedObject_Navigating;
            AssociatedObject.Navigated -= AssociatedObject_Navigated;
        }

        private void AssociatedObject_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            _isWork = true;
            NavigationSource = e.Uri.ToString();
            _isWork = false;

            if(AssociatedObject.Content is Page pagecontents && 
                pagecontents.DataContext is INavigationAware navigationAware)
            {
                navigationAware?.OnNavigated(sender, e);
            }
        }

        private void AssociatedObject_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            //Navigation 시작 상황을 부모뷰에 알립니다.
            if(AssociatedObject.Content is Page pagecontents &&
                pagecontents.DataContext is INavigationAware navigationAware)
            {
                navigationAware?.OnNavigating(sender, e);
            }
        }

        public static DependencyProperty NavigationSourceProperty = DependencyProperty.Register(nameof(NavigationSource), typeof(string), typeof(FrameBehavior), new PropertyMetadata(null, NavigationSourceChanged));

        private static void NavigationSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (FrameBehavior)d;
            if (behavior._isWork)
            {
                return;
            }
            behavior.Navigate();
        }

        private void Navigate()
        {
            switch(NavigationSource)
            {
                case "GoBack":
                    if(AssociatedObject.CanGoBack)
                    {
                        AssociatedObject.GoBack();
                    }
                    break;
                case "":
                case null:
                    break;
                default:
                    AssociatedObject.Navigate(new Uri(NavigationSource, UriKind.RelativeOrAbsolute));
                    break;
            }
        }
    }
}
