using CostManagerForms.Core.ViewModels.SignIn;
using CostManagerForms.UI.Pages.Base;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using SkiaSharp;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : BaseMvxContentPage<SignInViewModel>
    {
        public SignInPage()
        {
            InitializeComponent();
        }
    }
}
