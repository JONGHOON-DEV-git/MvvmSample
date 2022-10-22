using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVM_Example_dotnet6.behavior
{
    internal class ContentControlBehavior : Behavior<ContentControl>
    {
        public string ControlName
        {
            get { return (String)GetValue(ControlNameProperty); }
            set { SetValue(ControlNameProperty, value); }
        }

        public static readonly DependencyProperty ControlNameProperty =
            DependencyProperty.Register(nameof(ControlName), typeof(string), typeof(ContentControlBehavior), new PropertyMetadata(null, ControlNameChanged));

        private static void ControlNameChanged(DependencyObject obj ,  DependencyPropertyChangedEventArgs e)
        {
            ContentControlBehavior? behavior = obj as ContentControlBehavior;
            behavior?.ResolveControl();
        }

        private void ResolveControl()
        {
            if(string.IsNullOrEmpty(ControlName))
            {
                AssociatedObject.Content = null;
            }
            else
            {
                var type = Type.GetType($"MVVM_Example_dotnet6.Controls.{ControlName}, MVVM_Example_dotnet6, Version=1.0.0.0, Culture=neutral ,PublicToken=null");
                if(type == null)
                {
                    return;
                }
                var control = App.Current.Services.GetService(type);
                AssociatedObject.Content = control;
            }
        }

        public bool ShowLayerPopup
        {
            get { return (bool)GetValue(ShowLayerProperty); }
            set { SetValue(ShowLayerProperty, value); }
        }

        public static readonly DependencyProperty ShowLayerProperty = 
            DependencyProperty.Register(nameof(ShowLayerPopup), typeof(bool), typeof(ContentControlBehavior), new PropertyMetadata(false, ShowLayerPropertyChanged));

        private static void ShowLayerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = d as ContentControlBehavior;
            behavior.CheckShowLayerPopup();
        }

        private void CheckShowLayerPopup()
        {
            if(ShowLayerPopup == false)
            {
                AssociatedObject.Content = null;
            }
        }
    }
}
