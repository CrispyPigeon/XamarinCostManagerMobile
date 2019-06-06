using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.ViewModels.Costs;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CostDetailsPage : MvxContentPage<CostDetailsViewModel>
	{
		public CostDetailsPage ()
		{
			InitializeComponent ();
		}
	}
}
