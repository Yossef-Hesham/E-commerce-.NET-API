namespace DAL.system
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task Add(T entity);
        void Delete(T entity);

    }
}
