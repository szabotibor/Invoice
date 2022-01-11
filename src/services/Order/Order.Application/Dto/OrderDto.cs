using System;
using System.Collections.Generic;
using Order.Domain.Entity;

namespace Order.Application.Dto
{
    public class OrderDto
    {
        public int Id { get; }
        public int StoreId { get; }
        public DateTimeOffset OrderDate { get; }
        public DateTimeOffset DeliveryDate { get; }
        public decimal Total { get; }
        public IList<OrderItemDto>? Items { get; }


        public OrderDto(int storeId, DateTimeOffset orderDate, DateTimeOffset deliveryDate, decimal total,
            IList<OrderItemDto>? items = null)
        {
            StoreId = storeId;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            Total = total;
            Items = items;
        }
    }
}