using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Product.Application.Messaging.Base
{
    public abstract class HandlerWithResponseBase<TRequest, TDto> : IRequestHandler<TRequest, Result<TDto>>
        where TRequest : IRequest<Result<TDto>>
    {
        protected IMapper Mapper { get; }
        protected ILogger Logger { get; }


        protected HandlerWithResponseBase(IMapper mapper, ILogger logger)
        {
            Mapper = mapper;
            Logger = logger;
            Mapper = Guard.Against.Null(mapper, nameof(mapper));
            Logger = Guard.Against.Null(logger, nameof(logger));
        }

        public abstract Task<Result<TDto>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}