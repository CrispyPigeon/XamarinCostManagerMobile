using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmCross;
using Acr.UserDialogs;
using CostManagerForms.Core.ViewModels.SignIn;
using DAL.Services.RequestProvider;
using DAL.Services.CostManager;

namespace CostManagerForms.Core
{
    public class App : MvxApplication
    {
        private IMvxIoCProvider _ioC;

        public override void Initialize()
        {
            _ioC = Mvx.IoCProvider;

            _ioC.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            _ioC.ConstructAndRegisterSingleton<IRequestProvider, RequestProvider>();

            _ioC.ConstructAndRegisterSingleton<ICostManagerService, CostManagerService>();

            RegisterAppStart<SignInViewModel>();
        }
    }
}
