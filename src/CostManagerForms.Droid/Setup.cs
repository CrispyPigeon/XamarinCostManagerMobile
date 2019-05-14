using Acr.UserDialogs;
using Android.App;
using CostManagerForms.Core.Services.SqLite;
using CostManagerForms.Droid.Service.SqLite;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android;

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace CostManagerForms.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, UI.App>
    {
        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();

            IMvxIoCProvider ioC = Mvx.IoCProvider;

            ioC.RegisterSingleton<ISqLite>(new SqLiteService());

            UserDialogs.Init(() => ioC
                .Resolve<IMvxAndroidCurrentTopActivity>().Activity);
        }
    }
}
