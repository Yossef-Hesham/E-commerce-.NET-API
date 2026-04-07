

namespace BLL.System
{
    public interface IProductManager
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto?> GetProductById(int id);
        Task Create(ProductCreateDto product);
        Task Delete(int id);

    }
}
