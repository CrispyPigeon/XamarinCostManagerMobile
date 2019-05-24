using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmCross;
using Acr.UserDialogs;
using CostManagerForms.Core.ViewModels.SignIn;
using DAL.Services.RequestProvider;
using DAL.Services.CostManager;
using Xamarin.Forms;
using System;
using CostManagerForms.Core.ViewModels.Main;
using CostManagerForms.Core.ViewModels.CustomMain;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using CostManagerForms.Core.Services.Settings;

namespace CostManagerForms.Core
{
    public class App : MvxApplication
    {
        private IMvxIoCProvider _ioC;

        public override void Initialize()
        {
            _ioC = Mvx.IoCProvider;

            _ioC.RegisterSingleton<ISettings>(CrossSettings.Current);
            _ioC.ConstructAndRegisterSingleton<IAppSettings, AppSettings>();

            _ioC.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            _ioC.ConstructAndRegisterSingleton<IRequestProvider, RequestProvider>();

            _ioC.ConstructAndRegisterSingleton<ICostManagerService, CostManagerService>();
            
            StartViewModel();            
        }

        private void StartViewModel()
        {
            if (AppSettings.Instance.Token == string.Empty)
            {
                RegisterAppStart<SignInViewModel>();
            }
            else
            {
                RegisterAppStart<CustomMainViewModel>();
            }
        }
    }
}
