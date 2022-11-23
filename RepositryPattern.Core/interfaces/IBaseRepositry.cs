using RepositryPattern.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core.interfaces
{
    public interface IBaseRepositry<T> where T : class 
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T enttity);
        Task AddListAsync(List<T> entity);
        void Delete(T entity);
        T Update(T enttity);
    }
 
}
