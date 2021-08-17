using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


using BlockChain.Shared;

namespace BlockChain.Client.DataService
{
    public class BlockService
    {

        private readonly HttpClient client;
        private readonly PendingTransactionService pending;

        public BlockService(HttpClient client,PendingTransactionService pending)
        {

            this.client = client;
            this.pending = pending;
        }


        public async Task<List<BlockSummary>> GetBlocks()
        {


            var r = await client.GetFromJsonAsync<List<BlockSummary>>("/api/blocks");
            return r;
        }

        public async Task<Block> SummitNewBlockAsync(Block block)
        {
            var result = await client.PostAsJsonAsync<Block>("/api/blocks", block);
            if (result.IsSuccessStatusCode)
            {
                return block;
            }
            return null;
        }
        public async Task<List<Payload>> GetPayloads(string hash)
        {

            var r = await client.GetFromJsonAsync<List<Payload>>("/api/blocks/hash/payloads?hash=" + hash );
            return r;
        }
         
        public async Task<Block> MineBlock()
        {
            List<BlockSummary> blocks = await GetBlocks();

            var hash = blocks[blocks.Count - 1].Hash;
            var pendPayload = await pending.GetPayloads();
            Block block = new(DateTime.Now, hash, pendPayload);
            block.Mine(2);
            return block;
        }
    }
}

