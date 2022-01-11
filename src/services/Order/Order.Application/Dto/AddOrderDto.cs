using System;
using System.Collections.Generic;
using Order.Domain.Entity;

namespace Order.Application.Dto
{
    public class AddOrderDto
    {
        public int StoreId { get; }
        public DateTimeOffset OrderDate { get; }
        public DateTimeOffset DeliveryDate { get; }
        public decimal Total { get; }
        public IList<OrderItem> Items { get; }


        public AddOrderDto(int storeId, DateTimeOffset orderDate, DateTimeOffset deliveryDate, decimal total,
            IList<OrderItem> items)
        {
            StoreId = storeId;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            Total = total;
            Items = items;
        }
    }
}