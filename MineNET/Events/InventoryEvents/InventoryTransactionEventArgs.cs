﻿using System;
using MineNET.Inventories.Transactions;

namespace MineNET.Events.InventoryEvents
{
    public class InventoryTransactionEventArgs : EventArgs, ICancelable
    {
        public InventoryTransaction Transaction { get; }

        public bool IsCancel { get; set; }

        public InventoryTransactionEventArgs(InventoryTransaction transaction)
        {
            this.Transaction = transaction;
        }
    }
}
