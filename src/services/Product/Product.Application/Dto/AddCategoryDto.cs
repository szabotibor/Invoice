using Ardalis.GuardClauses;

namespace Product.Application.Dto
{
    public class AddCategoryDto
    {
        public string Name { get; }
        public string? SubCategoryName { get; }

        public AddCategoryDto(string name, string? subCategoryName = null)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            SubCategoryName = subCategoryName;
        }
    }
}