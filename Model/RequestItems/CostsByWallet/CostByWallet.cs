using System;
using System.Collections.Generic;
using System.Text;
using Model.RequestItems.CostsByWallet;

namespace Model.RequestItems
{
   public class CostByWallet
    {
        public WalletOfCosts Wallet { get; set; }

        public List<CostByCategory> Costs { get; set; }
    }
}
