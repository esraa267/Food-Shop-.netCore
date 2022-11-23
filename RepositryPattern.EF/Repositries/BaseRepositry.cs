using Microsoft.EntityFrameworkCore;
using RepositryPattern.Core.interfaces;
using RepositryPattern.Core.models;
using RepositryPattern.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.EF.Repositries
{
    public class BaseRepositry<T> : IBaseRepositry<T> where T : class
  
    {
        protected ApplicationDBContext _Context;
        public BaseRepositry(ApplicationDBContext context)
        {
            _Context = context;
        }

        public async Task<T> AddAsync(T enttity)
        {
            await  _Context.Set<T>().AddAsync(enttity);
            return enttity;
        }

        public async Task AddListAsync(List<T> entity)
        {
            await _Context.Set<T>().AddRangeAsync(entity);
        }

        public void Delete(T entity)
        {
            _Context.Remove(entity);
        }

      

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _Context.Set<T>().ToListAsync();
        }

        public async Task< T> GetByIdAsync(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }

        public T Update(T enttity)
        {
           _Context.Update(enttity);
            return enttity;
        }
    } 
}
