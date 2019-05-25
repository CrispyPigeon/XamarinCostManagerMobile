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
using MvvmCross.Forms.Platforms.Android.Views;
using CostManagerForms.Core.ViewModels.Main;
using Plugin.CurrentActivity;
using CarouselView.FormsPlugin.Android;

namespace CostManagerForms.Droid
{
    [Activity(Theme = "@style/AppTheme")]
    public class MainActivity : MvxFormsAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            CrossCurrentActivity.Current.Init(this, bundle);
            CarouselViewRenderer.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
        }
    }
}
