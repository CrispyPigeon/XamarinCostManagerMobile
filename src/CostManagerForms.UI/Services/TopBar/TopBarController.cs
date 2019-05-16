using CostManagerForms.UI.Services.TopBar;
using Xamarin.Forms;

namespace CostManagerForms.UI.Services.TopBar
{
    public class TopBarController : ITopBarController
    {
        public static TopBarController Instance { get; private set; }

        public TopBarController()
        {
            Instance = this;
        }

        public void ChangeToTransparentStatusBarColor()
        {
            var statusBarStyleManager = DependencyService.Get<ITopBarManager>();
            statusBarStyleManager.ChangeTopBarToTransparent();
        }
    }
}
