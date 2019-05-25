using System;
using System.Collections.Generic;
using System.Text;

namespace CostManagerForms.Core.ViewModels._Base
{
    public interface ITemplateDataViewModel
    {
        //<== Position of view-model for using correct data template ==>
        byte ViewModelPosition { get; }
    }
}
