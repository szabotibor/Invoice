using Ardalis.GuardClauses;
using FluentResults;
using MediatR;

namespace Invoice.Application.Messaging.Base
{
    public abstract class CommandWithResponseBase<TData, TResult> : IRequest<Result<TResult>>
    {
        public TData Data { get; }

        protected CommandWithResponseBase(TData data)
        {
            Data = Guard.Against.Null(data, nameof(data));
        }
    }
}