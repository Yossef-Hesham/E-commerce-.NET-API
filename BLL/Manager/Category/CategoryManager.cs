using DAL.system;


namespace BLL.System
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCategoryAsync(CategoryDto category)
        {
            var cate = new Category { Name = category.Name };
            await _unitOfWork._categoryRepo.Add(cate);
            await _unitOfWork.SaveChange();
        }

        public async Task<CategoryDto> GetById(int id)
        {
         
            var cate = await _unitOfWork._categoryRepo.GetCategorybyId(id);

            return new CategoryDto
            {
                Id = id,
                Name = cate?.Name
            };

        }

        public async Task<CategoryDto?> UpdateCategory(int id, string name)
        {
            var cate = await _unitOfWork._categoryRepo.GetCategorybyId(id);

            if (cate is null)
                return null;

            cate.Name = name;

            await _unitOfWork.SaveChange();

            return new CategoryDto
            {
                Id = cate.Id,
                Name = cate.Name
            };
        }
        public async Task DeleteCategory(int id)
        {
            var e = await _unitOfWork._categoryRepo.GetCategorybyId(id);

            if (e != null)
            {
                _unitOfWork._categoryRepo.Delete(e);
                await _unitOfWork.SaveChange();

            }
            else
            {
                throw new Exception("category not found");
            }

        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {

            var cat = await _unitOfWork._categoryRepo.GetAll();

            var catedto = cat.Select(e => new CategoryDto
            {
                Id = e.Id,
                Name = e.Name,

            });

            return catedto;
        }
    }
}
