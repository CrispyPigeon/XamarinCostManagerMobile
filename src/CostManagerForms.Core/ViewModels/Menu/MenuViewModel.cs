using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CostManagerForms.Core.Localization;
using CostManagerForms.Core.Services.Settings;
using CostManagerForms.Core.ViewModels.SignIn;
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
        public IMvxCommand LogOutCommand { get; }

        private readonly IMvxNavigationService _navigation;
        private readonly IUserDialogs _dialogs;

        public MenuViewModel(IMvxNavigationService navigation,
                             IUserDialogs dialogs)
        {
            _navigation = navigation;
            _dialogs = dialogs;

            CloseMenuCommand = new MvxAsyncCommand(() => _navigation.Close(this));
            LogOutCommand = new MvxAsyncCommand(LogOut);
        }



        private async Task LogOut()
        {
            var confirmed = await _dialogs.ConfirmAsync(
                AppResources.LogoutMessage,
                AppResources.LogoutTitle,
                cancelText: AppResources.No);

            if (confirmed)
            {
                AppSettings.Instance.SignOut();
                await _navigation.Navigate<SignInViewModel>();
            }
        }
    }
}
