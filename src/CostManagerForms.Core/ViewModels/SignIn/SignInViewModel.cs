using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Services.CostManager;
using MvvmCross.Commands;
using Xamarin.Forms;

namespace CostManagerForms.Core.ViewModels.SignIn
{
    public class SignInViewModel : BaseViewModel
    {
        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private bool _save = true;
        public bool Save
        {
            get => _save;
            set => SetProperty(ref _save, value);
        }

        public IMvxCommand SignInCommand { get; }

        private readonly ICostManagerService _costManagerService;

        public SignInViewModel(ICostManagerService costManagerService)
        {
            _costManagerService = costManagerService;

            SignInCommand = new MvxAsyncCommand(SignInAsync);
        }

        private async Task SignInAsync()
        {
            if (!ValidateLoginData())
                return;

            var login = await _costManagerService.SignInAsync(_login, _password);

            if (_save)
            {
                Application.Current.Properties["token"] = login.Token;
            }
            else
            {
                Application.Current.Properties["token"] = string.Empty;
            }
        }

        private bool ValidateLoginData()
        {
            if (string.IsNullOrEmpty(_login)
                && string.IsNullOrEmpty(_password))
                return false;
            return true;
        }
    }
}
