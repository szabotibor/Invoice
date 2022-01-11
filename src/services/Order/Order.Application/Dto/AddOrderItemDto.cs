namespace Order.Application.Dto
{
    public class AddOrderItemDto
    {
        public int ProductId { get; }
        public int Box { get; }
        public int Each { get; }
        public int Pound { get; }
        public decimal Price { get; }
        public string Market { get; }
        public int RouteId { get; }
        public string Note { get; }

        public AddOrderItemDto(int productId, int box, int each, int pound, decimal price, string market, string note,
            int routeId)
        {
            ProductId = productId;
            Box = box;
            Each = each;
            Pound = pound;
            Price = price;
            Market = market;
            Note = note;
            RouteId = routeId;
        }
    }
}