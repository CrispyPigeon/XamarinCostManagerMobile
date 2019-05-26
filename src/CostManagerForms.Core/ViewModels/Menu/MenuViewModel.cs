using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace CostManagerForms.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {

        public IMvxCommand CloseMenuCommand { get; }
        public IMvxCommand GoToMainPageCommand { get; }
        public IMvxCommand GoToEcoPlanPageCommand { get; }
        public IMvxCommand GoToSettingsPageCommand { get; }

        private readonly IMvxNavigationService _navigation;

        public MenuViewModel(IMvxNavigationService navigation)
        {

        }
    }
}
