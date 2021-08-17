using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Shared
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

    public class Payload
    {
        public string User { get; set; }
        public TransactionTypes TransactionTypes { get; set; }
        public string Item { get; set; }
        public int Amount { get; set; }

        public Payload(string user, TransactionTypes tp, string item, int amount)
        {
            User = user;
            TransactionTypes = tp;
            Item = item;
            Amount = amount;
        }
        public Payload()
        {

        }
    }
}
