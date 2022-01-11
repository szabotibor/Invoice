using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Dto;
using Product.Application.Messaging.Commands;
using Product.Application.Messaging.Queries;
using Store.Api.Controllers;

namespace Product.Api.Controllers
{
    public class ProductController : ApiControllerBase
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts(CancellationToken cancellationToken)
        {
            var result = await SendAsync(new GetAllProductsQuery(), cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddProduct(AddProductDto data, CancellationToken cancellationToken)
        {
            var result = await SendAsync(new AddProductCommand(data), cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStore(ProductDto data, CancellationToken cancellationToken)
        {
            var result = await SendAsync(new UpdateProductCommand(data), cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteStore(int id, CancellationToken cancellationToken)
        {
            var result = await SendAsync(new DeleteProductCommand(id), cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest();
        }
    }
}