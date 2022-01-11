namespace Product.Application.Dto
{
    public class CategoryDto
    {
        public int Id { get; }
        public string Name { get; }
        public string? SubCategoryName { get; }
        
        public CategoryDto(int id, string name, string? subCategoryName = null)
        {
            Id = id;
            Name = name;
            SubCategoryName = subCategoryName;
        }
    }
}