using DAL.Context;
using Microsoft.EntityFrameworkCore;


namespace DAL.system
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {

        public ProductRepo(AppDbContext context):base(context)
        {
            
        }
        public async Task<Product?> GetbyId(int id)
        {
            return await _context.Products.Include(e => e.Categoty).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Product>> Index()
        {
            return await _context.Products.Include(e => e.Categoty).ToListAsync();
        }


        

       
    }
}
