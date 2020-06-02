using System;
using System.Collections.Generic;
using System.Text;

namespace Model.RequestItems.Wallet
{
    public class Wallet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int StorageTypeID { get; set; }
        public int CurrencyID { get; set; }
        public int UserID { get; set; }
        public decimal Sum { get; set; }
        public decimal LastSum { get; set; }
    }
}
