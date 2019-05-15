using MvvmCross.IoC;
using MvvmCross.ViewModels;
using CostManagerForms.Core.ViewModels.Home;
using MvvmCross;
using Acr.UserDialogs;

namespace CostManagerForms.Core
{
    public class App : MvxApplication
    {
        private IMvxIoCProvider _ioC;

        public override void Initialize()
        {
            _ioC = Mvx.IoCProvider;

            _ioC.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            RegisterAppStart<HomeViewModel>();
        }
    }
}
