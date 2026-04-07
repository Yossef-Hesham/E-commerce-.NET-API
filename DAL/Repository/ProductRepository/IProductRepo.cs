namespace DAL.system
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        Task<IEnumerable<Product>> Index();

        Task<Product?> GetbyId(int id);


    }
}
