using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        Task GetById(int id);
        Task GetAll();
        Task Update(T entity);
        Task Delete(int id);
    }
}
