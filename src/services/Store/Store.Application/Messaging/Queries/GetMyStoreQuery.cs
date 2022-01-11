using FluentResults;
using MediatR;
using Store.Application.Dto;

namespace Store.Application.Messaging.Queries
{
    public class GetMyStoreQuery : IRequest<Result<StoreDto>>
    {

    }
}