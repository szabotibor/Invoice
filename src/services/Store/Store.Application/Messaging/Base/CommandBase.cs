using Ardalis.GuardClauses;
using FluentResults;
using MediatR;

namespace Store.Application.Messaging.Base
{
    public class CommandBase<TData> : IRequest<Result>
    {
        public TData Data { get; }

        protected CommandBase(TData data)
        {
            Data = Guard.Against.Null(data, nameof(data));
        }
    }
}