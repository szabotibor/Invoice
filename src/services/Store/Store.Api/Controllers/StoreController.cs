using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Dto;
using Store.Application.Messaging.Commands;
using Store.Application.Messaging.Queries;

namespace Store.Api.Controllers
{


    public class StoreController : ApiControllerBase
    {
        public StoreController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<StoreDto>>> GetAllStores(CancellationToken cancellationToken)
        {
            var result = await SendAsync(new GetAllStoresQuery(), cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest();
        }
        
        [HttpGet]
        [Route("mystore")]
        public async Task<ActionResult<List<StoreDto>>> GetMyStore(CancellationToken cancellationToken)
        {
            var result = await SendAsync(new GetMyStoreQuery(), cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest();
        }
        [HttpPut]
        [Route("mystore")]
        public async Task<ActionResult> UpdateMyStore(StoreDto data, CancellationToken cancellationToken)
        {
            var result = await SendAsync(new UpdateMyStoreCommand(data), cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<StoreDto>>> GetStore(int id, CancellationToken cancellationToken)
        {
            var result = await SendAsync(new GetStoreQuery(id), cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddStore(AddStorePayload data, CancellationToken cancellationToken)
        {
            var result = await SendAsync(new AddStoreCommand(data), cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStore(UpdateStorePayload data, CancellationToken cancellationToken)
        {
            var result = await SendAsync(new UpdateStoreCommand(data), cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteStore(int id, CancellationToken cancellationToken)
        {
            var result = await SendAsync(new DeleteStoreCommand(id), cancellationToken);

            return result.IsSuccess ? Ok() : BadRequest();
        }
    }
}