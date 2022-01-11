using FluentResults;
using Invoice.Application.Dto;
using MediatR;

namespace Invoice.Application.Messaging.Queries
{
    public class GetMyStoreQuery: IRequest<Result<StoreDto>>
    {
        
    }
}