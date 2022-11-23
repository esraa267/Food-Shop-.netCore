using RepositryPattern.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core.Dtos
{
    public class OrderProductDto :product
    {
        public int Quantity { get; set; }
    }
}
