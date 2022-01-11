using Ardalis.GuardClauses;

namespace Product.Domain.Entity
{
    public class Category
    {
        public int Id { get; }
        public string Name { get; }
        public string? SubCategoryName { get; }

        public Category(string name, string? subCategoryName = null)
        {
            Id = 0;
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            SubCategoryName = subCategoryName;
        }
        
        public Category(int id, string name, string? subCategoryName = null)
        {
            Id = Guard.Against.NegativeOrZero(id, nameof(id));
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            SubCategoryName = subCategoryName;
        }
    }
}