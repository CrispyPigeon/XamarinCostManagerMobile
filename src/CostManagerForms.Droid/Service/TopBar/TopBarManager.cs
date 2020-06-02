using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CostManagerForms.Droid.Service.TopBar;
using CostManagerForms.UI.Services.TopBar;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(TopBarManager))]
namespace CostManagerForms.Droid.Service.TopBar
{
    public class TopBarManager : ITopBarManager
    {
        public void ChangeTopBarToTransparent()
        {
            var currentWindow = GetCurrentWindow();
            WindowDrawSystemBar(currentWindow);
            WindowTranslucentNavigation(currentWindow);
            currentWindow.DecorView.SystemUiVisibility = 0;
            currentWindow.SetStatusBarColor(Android.Graphics.Color.Transparent);
        }

        private Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;

            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.ClearFlags(WindowManagerFlags.LayoutInOverscan);

            return window;
        }

        private void WindowDrawSystemBar(Window window)
        {
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
        }

        private void WindowTranslucentNavigation(Window window)
        {
            window.AddFlags(WindowManagerFlags.LayoutInOverscan);
        }
    }
}
