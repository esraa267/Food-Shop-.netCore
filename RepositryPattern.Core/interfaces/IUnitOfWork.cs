using RepositryPattern.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepositry<product>Products { get; }
        IBaseRepositry<order>Orders { get; }
        IBaseRepositry<OrderProduct> OrderProduct { get; }      

        int Complete();
       
    }
}
