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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IBaseRepositry<product> Products { get; private set; }
        public IBaseRepositry<order> Orders { get; private set; }
        public IBaseRepositry<OrderProduct> OrderProduct { get; private set; }


        public UnitOfWork( ApplicationDBContext context)
        {
            _context = context;
            Products = new BaseRepositry<product>(_context);
            Orders = new BaseRepositry<order>(_context);    
            OrderProduct = new BaseRepositry<OrderProduct>(_context);
         
        }
       

        public int Complete()
        {
          return _context.SaveChanges();    
        }

        public void Dispose()
        {
            _context.Dispose();      
        }
    }
}
