using Ardalis.GuardClauses;

namespace Order.Domain.Entity
{
    public class OrderItem
    {
        public int Id { get; }
        public int OrderId { get; }
        public Order Order { get; private set; }
        public int ProductId { get; }
        public int Box { get; }
        public int Each { get; }
        public int Pound { get; }
        public decimal Price { get; }
        public string Market { get; }
        public int RouteId { get; }
        public string Note { get; }

        public OrderItem(int id, int orderId, int productId, int box, int each, int pound, decimal price, string market, string note, int routeId)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            OrderId = Guard.Against.NegativeOrZero(orderId, nameof(orderId));
            ProductId = Guard.Against.NegativeOrZero(productId, nameof(productId));
            Box = Guard.Against.Negative(box, nameof(box));
            Each = Guard.Against.Negative(each, nameof(each));
            Pound = Guard.Against.Negative(pound, nameof(pound));
            Price = Guard.Against.NegativeOrZero(price, nameof(price));
            Market = market;
            Note = note;
            RouteId = Guard.Against.NegativeOrZero(routeId, nameof(routeId));
        }
    }
}