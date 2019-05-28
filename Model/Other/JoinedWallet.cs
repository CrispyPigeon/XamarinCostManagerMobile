using System;
using System.Collections.Generic;
using System.Text;
using Model.RequestItems.Currency;
using Model.RequestItems.StorageType;
using Model.RequestItems.Wallet;

namespace Model.Other
{
    public class JoinedWallet
    {
        public JoinedWallet(Wallet wallet,
                            StorageType storageType,
                            Currency currency)
        {
            Wallet = wallet;
            StorageType = storageType;
            Currency = currency;
        }

        public Wallet Wallet { get; set; }

        public StorageType StorageType { get; set; }

        public Currency Currency { get; set; }
    }
}
