using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.ViewModels.Costs;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Controls.Views.Costs
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CostsView : MvxContentView<CustomMainCostsViewModel>
    {
		public CostsView ()
		{
			InitializeComponent ();
		}
	}
}
