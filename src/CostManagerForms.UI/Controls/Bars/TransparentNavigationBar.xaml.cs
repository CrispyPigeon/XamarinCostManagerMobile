using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Controls.Bars
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TransparentNavigationBar : ContentView
	{

	    private string titleLabelText;
	    public string TitleLabelText
	    {
	        get => titleLabelText;
	        set
	        {
	            titleLabelText = value;
	            SetTitleText(value);
	        }
	    }

	    public TransparentNavigationBar()
	    {
	        InitializeComponent();
	    }

	    private void SetTitleText(string value)
	    {
	        TitleLabel.Text = value;
	    }
	}
}
