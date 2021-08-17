using BlockChain.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain.Server.Dataservice
{
    public class BlockchainService
    {
       
        private readonly Blockchain blockchain;
        private readonly PendingPayloads pendingPayloads;

        public BlockchainService(Blockchain blockchain, PendingPayloads pendingPayloads)
        {
            
            this.blockchain = blockchain;
            this.pendingPayloads = pendingPayloads;
        }
        public Block SubmitNewBlock(int nounce, DateTime timestamp)
        {
            var pendingPayload = pendingPayloads.ListofPayload();
            Block block = new();
            block.TimeStamp = timestamp;
            block.Nonce = nounce;
            block.PreviousHash = blockchain.GetLatestBlock().Hash;
            block.Data = pendingPayload;
            block.Hash = block.CalculateHash();

            if (blockchain.IsValid())
            {
                blockchain.AddBlock(block);
                pendingPayloads.RemovePaylod();
                return block;
            }
            return null;

        }
    }
}
