using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IMediator Mediator { get; }

        protected ApiControllerBase(IMediator mediator)
        {
            Mediator = Guard.Against.Null(mediator, nameof(mediator));
        }

        protected Task<TResult> SendAsync<TResult>(
            IRequest<TResult> request,
            CancellationToken cancellationToken)
        {
            return Mediator.Send(request, cancellationToken);
        }

    }
}