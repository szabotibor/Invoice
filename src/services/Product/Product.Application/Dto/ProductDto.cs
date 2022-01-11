namespace Product.Application.Dto
{
    public class ProductDto
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }
        public string? Note { get; }
        public string? Category { get; }
        public string? SubCategory { get; }

        public ProductDto(int id, string name, decimal price, int quantity, string? note, string? category,
            string? subCategory)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Note = note;
            Category = category;
            SubCategory = subCategory;
        }
    }
}