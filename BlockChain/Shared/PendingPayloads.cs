using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Shared
{
   public class PendingPayloads
    {
        List<Payload> Payloads = new();



        public List<Payload> ListofPayload()
        {
            return Payloads;
        }

        public void AddPayload(Payload payload)
        {
            Payloads.Add(payload);
        }
        public void RemovePaylod()
        {
            Payloads = new List<Payload>();

        }
    }
}
