using CostManagerForms.Core.ViewModels.SignIn;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class SignInPage : MvxContentPage<SignInViewModel>
    {
        public SignInPage()
        {
            InitializeComponent();
        }
    }
}
