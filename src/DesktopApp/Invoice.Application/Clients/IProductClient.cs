using FluentResults;
using Invoice.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Invoice.Application.Clients
{
    public interface IProductClient
    {
        Task<List<CategoryDto>> GetProductCategories(CancellationToken cancellationToken);
        Task<List<ProductDto>> GetProducts(CancellationToken cancellationToken);
        Task<Result> DeleteProduct(int id, CancellationToken cancellationToken);
        Task<Result> AddProduct(ProductDto data, CancellationToken cancellationToken);
        Task<Result> UpdateProduct(ProductDto data, CancellationToken cancellationToken);
        Task<Result> AddCategory(CategoryDto data, CancellationToken cancellationToken);
        Task<Result> UpdateCategory(CategoryDto data, CancellationToken cancellationToken);
        Task<Result> DeleteCategory(int id, CancellationToken cancellationToken);
    }
}
