using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Ardalis.GuardClauses;

namespace Order.Domain.Entity
{
    public class Order
    {
        public int Id { get; }
        public int StoreId { get; }
        public DateTimeOffset OrderDate { get; }
        public DateTimeOffset DeliveryDate { get; }
        public decimal Total { get; }
        public virtual IList<OrderItem> Items { get; } = new List<OrderItem>();
        
        public Order(int storeId, DateTimeOffset orderDate, DateTimeOffset deliveryDate, decimal total, IList<OrderItem> items)
        {
            Id = 0;
            StoreId = Guard.Against.NegativeOrZero(storeId, nameof(storeId));
            OrderDate = Guard.Against.Null(orderDate, nameof(orderDate));
            DeliveryDate = Guard.Against.Null(deliveryDate, nameof(deliveryDate));
            Total = Guard.Against.NegativeOrZero(total, nameof(total));
            Items = Guard.Against.Null(items, nameof(items));
        }

        public Order(int id, int storeId, DateTimeOffset orderDate, DateTimeOffset deliveryDate, decimal total, IList<OrderItem> items)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            StoreId = Guard.Against.NegativeOrZero(storeId, nameof(storeId));
            OrderDate = Guard.Against.Null(orderDate, nameof(orderDate));
            DeliveryDate = Guard.Against.Null(deliveryDate, nameof(deliveryDate));
            Total = Guard.Against.NegativeOrZero(total, nameof(total));
            Items = Guard.Against.Null(items, nameof(items));
        }
    }
}