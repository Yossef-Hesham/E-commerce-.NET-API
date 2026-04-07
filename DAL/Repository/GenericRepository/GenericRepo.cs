using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.system
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly AppDbContext _context;


        public GenericRepo(AppDbContext context)
        {
            _context = context;
        }
        

        public async Task<IEnumerable<T>> GetAll()
        {
           return  await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);   
        }

        public void Delete(T entity)
        {
             _context.Set<T>().Remove(entity);
        }

       
    }
}
