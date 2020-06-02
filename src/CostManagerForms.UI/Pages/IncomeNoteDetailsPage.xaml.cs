using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.ViewModels.IncomeNotes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IncomeNoteDetailsPage : MvxContentPage<IncomeNoteDetailsViewModel>
	{
		public IncomeNoteDetailsPage ()
		{
			InitializeComponent ();
		}
	}
}
