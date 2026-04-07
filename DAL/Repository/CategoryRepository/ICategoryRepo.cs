using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.system
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        Task<Category?> GetCategorybyId(int id);

    }
}
