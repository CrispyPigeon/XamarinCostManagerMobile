using CostManagerForms.Core.ViewModels.CustomMain;
using CostManagerForms.UI.Pages.Base;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true, NoHistory = true)]
    public partial class CustomMainPage : BaseMvxContentPage<CustomMainViewModel>
    {
        public CustomMainPage ()
        {
            InitializeComponent();
            CarouselViewControl.PositionSelected += BottomSelectorTemplateView.CarouselViewPositionSelected;
        }
    }
}
