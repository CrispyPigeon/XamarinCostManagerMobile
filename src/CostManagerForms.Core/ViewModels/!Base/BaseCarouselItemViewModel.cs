using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CostManagerForms.Core.ViewModels._Base
{
    public abstract class BaseCarouselItemViewModel : BaseViewModel
    {
        public void ViewLoaded()
        {
            LoadData();
        }

        public abstract Task LoadData();
    }
}
