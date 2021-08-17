using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using BlockChain.Shared;

namespace BlockChain.Client.DataService
{
    public class PendingTransactionService
    {
        private readonly HttpClient client;
       

       
        public PendingTransactionService(HttpClient Client)
        {
            client = Client;
        }
        
        public async Task<List<Payload>> GetPayloads(){

            return await client.GetFromJsonAsync<List<Payload>>("/api/PendingPayloads");
        }
        
        public async Task<string> AddPayload(Payload payload)
        {
            var resmassage = await client.PostAsJsonAsync("/api/PendingPayloads", payload);
            string mass;
            if (resmassage.IsSuccessStatusCode)
            {
                mass = resmassage.StatusCode.ToString();
            }
            else
            {
                mass = "Error to adding Payload";
            }
            return mass;
        }

    }
}
