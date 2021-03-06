using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Shared
{
   public class Blockchain
    {
        public IList<Block> Chain { get; set; }

        public int Difficulty { get; set; } = 2;

        public Blockchain()
        {
            InitializeChain();
            AddGenesisBlock();
        }
        public void InitializeChain()
        {
            Chain = new List<Block>();
        }
       
        public void AddGenesisBlock()
        {

            Chain.Add(new Block(DateTime.Now, null, new List<Payload>()));
        }
        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }
        public void AddBlock(Block block)
        {
            Block latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public bool IsValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;


        }
    }
}
