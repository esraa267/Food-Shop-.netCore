using RepositryPattern.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core.Dtos
{
    public class OrderDto
    {
        public order? order { get; set; }

        public List<OrderProductDto>? orderProduct { get; set; }
    }
}
