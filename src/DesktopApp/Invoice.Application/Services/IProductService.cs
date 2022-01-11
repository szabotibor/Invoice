using FluentResults;
using Invoice.Application.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Invoice.Application.Services
{
    public interface IProductService
    {
        Task<Result> AddCategory(CategoryDto data, CancellationToken cancellationToken);
        Task<Result> AddProduct(ProductDto data, CancellationToken cancellationToken);
        Task<Result> DeleteCategory(int id, CancellationToken cancellationToken);
        Task<Result> DeleteProduct(int id, CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetProductCategories(CancellationToken cancellationToken);
        Task<List<ProductDto>> GetProducts(CancellationToken cancellationToken);
        Task<Result> UpdateProduct(ProductDto data, CancellationToken cancellationToken);
    }
}