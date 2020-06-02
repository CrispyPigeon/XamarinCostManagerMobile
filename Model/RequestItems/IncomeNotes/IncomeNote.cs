using System;
using System.Collections.Generic;
using System.Text;

namespace Model.RequestItems.IncomeNotes
{
    public class IncomeNote
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int WalletID { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
    }
}
