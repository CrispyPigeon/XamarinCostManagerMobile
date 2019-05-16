using System;
using System.Collections.Generic;
using System.Text;
using CostManagerForms.UI.Services.TopBar;
using MvvmCross.Forms.Views;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace CostManagerForms.UI.Pages.Base
{
    public class BaseMvxContentPage<TViewModel> : MvxContentPage<TViewModel>
        where TViewModel : class, IMvxViewModel
    {

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            TopBarController.Instance.ChangeToTransparentStatusBarColor();
        }
    }
}
