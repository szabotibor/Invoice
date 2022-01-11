using Store.Application.Dto;
using Store.Application.Messaging.Base;

namespace Store.Application.Messaging.Queries
{
    public class GetStoreQuery : QueryBase<int, StoreDto>
    {
        public GetStoreQuery(int data) : base(data)
        {
        }
    }
}