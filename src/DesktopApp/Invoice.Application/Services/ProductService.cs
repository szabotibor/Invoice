using Ardalis.GuardClauses;
using FluentResults;
using Invoice.Application.Clients;
using Invoice.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Invoice.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductClient _client;

        public ProductService(IProductClient client)
        {
            _client = Guard.Against.Null(client, nameof(client));
        }

       
        public async Task<List<CategoryDto>> GetProductCategories(CancellationToken cancellationToken)
        {
            return await _client.GetProductCategories(cancellationToken);
        }

        public async Task<Result> AddCategory(CategoryDto data, CancellationToken cancellationToken)
        {
            return await _client.AddCategory(data, cancellationToken);
        }

        public async Task<Result> UpdateCategory(CategoryDto data, CancellationToken cancellationToken)
        {
            return await _client.UpdateCategory(data, cancellationToken);
        }
        public async Task<Result> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            return await _client.DeleteCategory(id, cancellationToken);
        }

        public async Task<List<ProductDto>> GetProducts(CancellationToken cancellationToken)
        {
            return await _client.GetProducts(cancellationToken);
        }

        public async Task<Result> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            return await _client.DeleteProduct(id, cancellationToken);
        }

        public async Task<Result> AddProduct(ProductDto data, CancellationToken cancellationToken)
        {
            return await _client.AddProduct(data, cancellationToken);
        }

        public async Task<Result> UpdateProduct(ProductDto data, CancellationToken cancellationToken)
        {
            return await _client.UpdateProduct(data, cancellationToken);
        }
    }
}
