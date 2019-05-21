using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CostManagerForms.Core.ViewModels._Base
{
    public abstract class BaseCarouselItemViewModel : BaseViewModel
    {
        public async void ViewLoaded()
        {
            await Task.Run(LoadData);
        }

        public abstract Task LoadData();
    }
}
