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


    public class CategoryController : ApiControllerBase
    {
        public CategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories(CancellationToken cancellationToken)
        {
            var result = await SendAsync(new GetCategoriesQuery(), cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddCategory(AddCategoryDto data, CancellationToken cancellationToken)
        {
            var result = await SendAsync(new AddCategoryCommand(data), cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStore(CategoryDto data, CancellationToken cancellationToken)
        {
            var result = await SendAsync(new UpdateCategoryCommand(data), cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteStore(int id, CancellationToken cancellationToken)
        {
            var result = await SendAsync(new DeleteCategoryCommand(id), cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest();
        }
    }
}