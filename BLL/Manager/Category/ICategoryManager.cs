

namespace BLL.System
{
    public interface ICategoryManager
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task CreateCategoryAsync(CategoryDto category);

        Task<CategoryDto> GetById(int id);

        Task DeleteCategory(int id);
        Task<CategoryDto> UpdateCategory(int id, string name);

    }
}
