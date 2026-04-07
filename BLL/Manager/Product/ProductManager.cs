using DAL.system;

namespace BLL.System
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IProductRepo _ProductRepo;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _unitOfWork._ProductRepo.Index();

            return products.Select(e => new ProductDto
            {
                Id = e.Id,
                Name = e.Name,
                Desciption = e.Desciption,
                Price = e.Price,
                Stock = e.Stock,
                CategotyName = e.Categoty?.Name ?? "No Category"  // shorter, same result
            });
        }

        public async Task<ProductDto?> GetProductById(int id)
        {
            var e = await _unitOfWork._ProductRepo.GetbyId(id);

            if (e is null)
                return null;

            var productdto = new ProductDto
            {
                Id = e.Id,
                Name = e.Name,
                Desciption = e.Desciption,
                Price = e.Price,
                Stock = e.Stock,
                CategotyName = e.Categoty?.Name ?? "No Category"  

            };
                return productdto;
        }

        public async Task Create(ProductCreateDto product)
        {
            var productdto = new Product()
            {
                Name = product.Name,
                Desciption = product.Desciption,
                Stock = product.Stock,
                Price = product.Price,
                CategotyId = product.CategoryId
            };

            await _unitOfWork._ProductRepo.Add(productdto);
            await _unitOfWork.SaveChange();
        }



        public async Task Delete(int id)
        {
            var e = await _unitOfWork._ProductRepo.GetbyId(id);

            if(e != null)
            {
                 _unitOfWork._ProductRepo.Delete(e);
                await _unitOfWork.SaveChange();

            }else
            {
                throw new Exception("Product not found");
            }

        }

       
    }
}
