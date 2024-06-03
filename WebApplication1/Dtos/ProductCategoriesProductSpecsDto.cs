namespace WebApplication1.Dtos
{
    public class ProductCategoriesProductSpecsDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public CategoryDto Category { get; set; }
        public ProductSpecsDto ProductSpecs { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
