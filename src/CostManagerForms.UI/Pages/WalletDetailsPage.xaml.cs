using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.ViewModels.Wallets;
using CostManagerForms.UI.Pages.Base;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletDetailsPage : MvxContentPage<WalletDetailsViewModel>
    {
        public WalletDetailsPage()
        {
            InitializeComponent();
        }
    }
}
