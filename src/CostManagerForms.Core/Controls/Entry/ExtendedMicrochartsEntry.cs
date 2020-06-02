using System;
using System.Collections.Generic;
using System.Text;

namespace CostManagerForms.Core.Controls.Entry
{
    public class ExtendedMicrochartsEntry : Microcharts.Entry
    {
        public string RgbColor { get; set; }

        public ExtendedMicrochartsEntry(float value) : base(value)
        {
        }
    }
}
