namespace WebAPI.DTOs.Category
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SubcategoryDto> Subcategories { get; set; }
    }
}
