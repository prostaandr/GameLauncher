using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T Entity);
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task Update(T Entity);
        Task Delete(T Entity);
    }
}
