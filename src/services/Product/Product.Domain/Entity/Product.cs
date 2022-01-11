using Ardalis.GuardClauses;

namespace Product.Domain.Entity
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }
        public string? Note { get; }
        public string? Category { get; }
        public string? SubCategory { get; }
        
        public Product(string name, decimal price, int quantity, string category, string? subCategory, string? note)
        {
            Id = 0;
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Price = Guard.Against.Negative(price, nameof(price));
            Quantity = Guard.Against.Negative(quantity, nameof(quantity));
            Note = note;
            Category = category;
            SubCategory = subCategory;
        }

        public Product(int id, string name, decimal price, int quantity, string category, string? subCategory,string? note)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Price = Guard.Against.Negative(price, nameof(price));
            Quantity = Guard.Against.Negative(quantity, nameof(quantity));
            Note = note;
            Category = category;
            SubCategory = subCategory;
        }
    }
}