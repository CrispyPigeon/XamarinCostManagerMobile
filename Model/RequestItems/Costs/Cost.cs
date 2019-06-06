using System;
using System.Collections.Generic;
using System.Text;

namespace Model.RequestItems.Costs
{
    public class Cost
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int WalletID { get; set; }
        public int UserID { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }
        public int CostCategoryID { get; set; }
    }
}
