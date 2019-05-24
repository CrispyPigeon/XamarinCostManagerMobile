using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.ViewModels.Statistics;
using CostManagerForms.UI.Pages.Base;
using MvvmCross;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxTabbedPagePresentation(TabbedPosition.Tab)]
    public partial class CustomMainStatisticPage : BaseMvxContentPage<CustomMainStatisticViewModel>
    {
		public CustomMainStatisticPage ()
		{
			InitializeComponent (); //TODO Use Icons for tab items
        }
	}
}
