namespace BLL.System
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Desciption { get; set; }
        
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? CategotyName { get; set; }

    }
}
