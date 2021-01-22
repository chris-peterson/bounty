using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using bounty.Domain;

namespace WebUi.ServiceClients
{
    public class BountyWebServiceClient
    {
        readonly HttpClient _httpClient;

        public BountyWebServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:5001/");
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _httpClient.GetAsync("accounts")
                .Result.Content.ReadFromJsonAsync<IEnumerable<Account>>();
        }

        public async Task SaveTransaction(Transaction transaction)
        {
            var response = await _httpClient.PostAsJsonAsync("transactions", transaction);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            var response = await _httpClient.GetAsync("transactions");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Transaction>>();
        }
    }
}
