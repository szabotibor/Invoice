using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using FluentResults;
using Invoice.Application.Clients;
using Invoice.Application.Dto;
using Invoice.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Invoice.Infrastructure.Clients
{
    public class StoreClient: IStoreClient
    {
        private readonly IOptions<StoreApiOptions> _options;
        private readonly HttpClient _httpClient;

        public StoreClient(IOptions<StoreApiOptions> options)
        {
            _options = Guard.Against.Null(options, nameof(options));
            
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_options.Value.BaseUrl)
            };
        }

        public async Task<StoreDto?> GetMyStoreAsync(CancellationToken cancellationToken)
        {
            var result = await _httpClient.GetAsync("/api/Store/mystore", cancellationToken);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<StoreDto>(content);
            }

            return null;
        }

        public async Task<Result> UpdateMyStoreAsync(StoreDto store, CancellationToken cancellationToken)
        {

            var result = await _httpClient.PutAsync("/api/Store/mystore", new StringContent(JsonConvert.SerializeObject(store), Encoding.UTF8, "application/json"), cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                return Result.Ok();
            }

            return Result.Fail("Error while saving data");
        }

        public async Task<Result> DeleteStore(int id, CancellationToken cancellationToken)
        {
            var result = await _httpClient.DeleteAsync($"/api/Store/{id}", cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                return Result.Ok();
            }

            return Result.Fail("Error while saving data");
        }

        public async Task<Result<List<StoreDto>>> GetStores(CancellationToken cancellationToken)
        {
            var result = await _httpClient.GetAsync("/api/Store/all", cancellationToken);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<List<StoreDto>>(content);
                if(data != null)
                    return Result.Ok(data);
            }

            return Result.Fail("Error while retrieving data");
        }

        public async Task<Result> AddStore(StoreDto store, CancellationToken cancellationToken)
        {
            var result = await _httpClient.PostAsync("/api/Store", new StringContent(JsonConvert.SerializeObject(store), Encoding.UTF8, "application/json"), cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                return Result.Ok();
            }

            return Result.Fail("Error while saving data");
        }

        public async Task<Result> UpdateStoreAsync(StoreDto store, CancellationToken cancellationToken)
        {
            var content = JsonConvert.SerializeObject(store);
            var result = await _httpClient.PutAsync("/api/Store", new StringContent(content, Encoding.UTF8, "application/json"), cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                return Result.Ok();
            }

            return Result.Fail("Error while saving data");
        }
    }
}