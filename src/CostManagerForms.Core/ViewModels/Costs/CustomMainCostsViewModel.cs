using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.ViewModels._Base;

namespace CostManagerForms.Core.ViewModels.Costs
{
    public class CustomMainCostsViewModel : BaseCarouselItemViewModel, ITemplateDataViewModel
    {
        public byte ViewModelPosition => 2;

        public CustomMainCostsViewModel()
        {

        }

        public override async Task LoadData()
        {

        }
    }
}
