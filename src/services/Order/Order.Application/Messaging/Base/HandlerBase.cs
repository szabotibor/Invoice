using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Order.Application.Messaging.Base
{
    public abstract class HandlerBase<TRequest> : IRequestHandler<TRequest, Result> where TRequest : IRequest<Result>
    {
        protected IMapper Mapper { get; }
        protected ILogger Logger { get; }


        protected HandlerBase(IMapper mapper, ILogger logger)
        {
            Mapper = mapper;
            Logger = logger;
            Logger = Guard.Against.Null(logger, nameof(logger));
        }

        public abstract Task<Result> Handle(TRequest request, CancellationToken cancellationToken);
    }
}