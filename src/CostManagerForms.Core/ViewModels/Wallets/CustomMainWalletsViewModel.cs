using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CostManagerForms.Core.ViewModels._Base;

namespace CostManagerForms.Core.ViewModels.Wallets
{
    public class CustomMainWalletsViewModel : BaseCarouselItemViewModel, ITemplateDataViewModel
    {
        public byte ViewModelPosition => 0;

        public CustomMainWalletsViewModel()
        {

        }

        public override async Task LoadData()
        {
            
        }
    }
}
