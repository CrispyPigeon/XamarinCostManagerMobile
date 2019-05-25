using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.ViewModels.Wallets;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Controls.Views.Wallets
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WalletsView : MvxContentView<CustomMainWalletsViewModel>
    {
		public WalletsView ()
		{
			InitializeComponent ();
		}
	}
}
