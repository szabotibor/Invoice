using Ardalis.GuardClauses;
using FluentResults;
using Invoice.Application.Clients;
using Invoice.Application.Dto;
using Invoice.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Invoice.Infrastructure.Clients
{
    public class ProductClient: IProductClient
    {
        private readonly IOptions<ProductApiOptions> _options;
        private readonly HttpClient _httpClient;

        public ProductClient(IOptions<ProductApiOptions> options)
        {
            _options = Guard.Against.Null(options, nameof(options));

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_options.Value.BaseUrl)
            };
        }

        public async Task<Result> AddCategory(CategoryDto data, CancellationToken cancellationToken)
        {
            var result = await _httpClient.PostAsync("/api/category", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                return Result.Ok();
            }

            return Result.Fail("Error while saving data");
        }

        public async Task<Result> AddProduct(ProductDto data, CancellationToken cancellationToken)
        {
            var result = await _httpClient.PostAsync("/api/product", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                return Result.Ok();
            }

            return Result.Fail("Error while saving data");
        }

        public async Task<Result> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            var result = await _httpClient.DeleteAsync($"/api/category/{id}", cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                return Result.Ok();
            }

            return Result.Fail("Error while saving data");
        }

        public async Task<Result> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var result = await _httpClient.DeleteAsync($"/api/product/{id}", cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                return Result.Ok();
            }

            return Result.Fail("Error while saving data");
        }

        public async Task<List<CategoryDto>> GetProductCategories(CancellationToken cancellationToken)
        {
            var result = await _httpClient.GetAsync("/api/category/all", cancellationToken);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<CategoryDto>>(content);
            }

            return new List<CategoryDto>();
        }

        public async Task<List<ProductDto>> GetProducts(CancellationToken cancellationToken)
        {
            var result = await _httpClient.GetAsync("/api/product/all", cancellationToken);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ProductDto>>(content);
            }

            return new List<ProductDto>();
        }

        public async Task<Result> UpdateCategory(CategoryDto data, CancellationToken cancellationToken)
        {
            var result = await _httpClient.PutAsync("/api/category", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                return Result.Ok();
            }

            return Result.Fail("Error while saving data");
        }

        public async Task<Result> UpdateProduct(ProductDto data, CancellationToken cancellationToken)
        {
            var result = await _httpClient.PutAsync("/api/product", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"), cancellationToken);

            if (result.IsSuccessStatusCode)
            {
                return Result.Ok();
            }

            return Result.Fail("Error while saving data");
        }
    }
}
