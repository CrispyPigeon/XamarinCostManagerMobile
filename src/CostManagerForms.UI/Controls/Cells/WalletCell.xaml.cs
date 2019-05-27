using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Controls.Cells
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WalletCell : ViewCell
	{
		public WalletCell ()
		{
			InitializeComponent (); //TODO GET STORAGETYPE AND CURRENCY
		}
	}
}
