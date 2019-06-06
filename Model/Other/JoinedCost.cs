using System;
using System.Collections.Generic;
using System.Text;
using Model.RequestItems.CostCategory;
using Model.RequestItems.Costs;
using Model.RequestItems.Currency;
using Model.RequestItems.Wallet;

namespace Model.Other
{
    public class JoinedCost
    {
        public JoinedCost(Cost cost,
                          JoinedWallet wallet,
                          CostCategory costCategory)
        {
            Cost = cost;
            Wallet = wallet;
            CostCategory = costCategory;
        }

        public Cost Cost { get; set; }

        public JoinedWallet Wallet { get; set; }

        public CostCategory CostCategory { get; set; }
    }
}
