using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Shared
{
    public  class BlockSummary
    {
        public int Index { get; set; }
        public DateTime Stamp { get; set; }
        public string PreviousBlock { get; set; }
        public string Hash { get; set; }
        public int Nounce { get; set; }
    }
}
