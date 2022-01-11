using Ardalis.GuardClauses;
using FluentResults;
using MediatR;

namespace Order.Application.Messaging.Base
{
    public abstract class QueryBase<TData, TDto> : IRequest<Result<TDto>>
    {
        public TData Data { get; }

        protected QueryBase(TData data)
        {
            Data = Guard.Against.Null(data, nameof(data));
        }
    }
}