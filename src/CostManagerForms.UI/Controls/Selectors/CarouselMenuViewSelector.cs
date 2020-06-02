using System;
using System.Collections.Generic;
using System.Text;
using CostManagerForms.Core.ViewModels._Base;
using Xamarin.Forms;

namespace CostManagerForms.UI.Controls.Selectors
{
    public class CarouselMenuViewSelector : DataTemplateSelector
    {
        public List<DataTemplate> ViewTemplates { get; set; }

        public CarouselMenuViewSelector()
        {
            ViewTemplates = new List<DataTemplate>();
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var tab = (ITemplateDataViewModel)item;
            DataTemplate template = null;
            template = ViewTemplates[tab.ViewModelPosition];
            return template;
        }
    }
}
