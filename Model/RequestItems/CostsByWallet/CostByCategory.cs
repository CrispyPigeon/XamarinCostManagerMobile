using System;
using System.Collections.Generic;
using System.Text;

namespace Model.RequestItems.CostsByWallet
{
    public class CostByCategory
    {
        public string CategoryName { get; set; }

        public string RgbColor { get; set; }

        public decimal Sum { get; set; }
    }
}
