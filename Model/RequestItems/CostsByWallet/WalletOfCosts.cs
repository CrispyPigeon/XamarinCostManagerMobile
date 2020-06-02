using System;
using System.Collections.Generic;
using System.Text;

namespace Model.RequestItems.CostsByWallet
{
    public class WalletOfCosts
    {
        public string Name { get; set; }

        public string Currency { get; set; }

        public decimal Sum { get; set; }

        public decimal LastSum { get; set; }
    }
}
