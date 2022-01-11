namespace Product.Application.Dto
{
    public class AddProductDto
    {
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }
        public string? Note { get; }
        public string? Category { get; }
        public string? SubCategory { get; }
        
        public AddProductDto(string name, decimal price, int quantity, string? note, string? category, string? subCategory)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Note = note;
            Category = category;
            SubCategory = subCategory;
        }

    }
}