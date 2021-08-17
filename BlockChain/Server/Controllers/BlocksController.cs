using BlockChain.Server.Dataservice;
using BlockChain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        private readonly Blockchain blockchain;
        private readonly BlockchainService service;

        

        public BlocksController(Blockchain blockchain, BlockchainService service)
        {
            this.blockchain = blockchain;
            this.service = service;
        }


        [HttpGet]
        public ActionResult<List<BlockSummary>> GetAllBlock()
        {

            List<BlockSummary> blockSummaries = new();

            foreach (var item in blockchain.Chain)
            {
                BlockSummary blockSummary = new()
                {
                    Index = item.Index,
                    Hash = item.Hash,
                    Stamp = item.TimeStamp,
                    PreviousBlock = item.PreviousHash,
                    Nounce = item.Nonce

                };
                blockSummaries.Add(blockSummary);
            }



            return blockSummaries;
        }
        [HttpGet("{hash}")]
        public ActionResult<Block> GetBlock(string hash)
        {

            var block = blockchain.Chain.Where(b => b.Hash == hash).FirstOrDefault();
            if (block == null)
            {
                return NotFound();
            }
            return block;

        }

        [HttpGet("hash/payloads")]
        public ActionResult<List<Payload>> GetPayloads(string hash)
        {


            var bd = blockchain.Chain.Where(d => d.Hash == hash).SelectMany(b => b.Data).ToList();


            return bd;

        }

        [HttpPost]
        public ActionResult<Block> PostBlock(Block block)
        {
            if (block == null)
            {
                return NotFound();
            }
            var newblock = service.SubmitNewBlock(block.Nonce, block.TimeStamp);
            if (newblock == null)
            {
                return BadRequest();
            }
            return newblock;
        }

    }
}
