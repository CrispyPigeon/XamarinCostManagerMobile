using MvvmCross.IoC;
using MvvmCross.ViewModels;
using CostManagerForms.Core.ViewModels.Home;

namespace CostManagerForms.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<HomeViewModel>();
        }
    }
}
