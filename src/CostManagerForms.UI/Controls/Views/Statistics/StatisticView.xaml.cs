using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.ViewModels.Statistics;
using MvvmCross.Forms.Views;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CostManagerForms.UI.Controls.Views.Statistics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticView : MvxContentView<CustomMainStatisticViewModel>
    {
        public StatisticView()
        {
            InitializeComponent();
        }
    }
}
