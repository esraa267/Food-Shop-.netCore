﻿using RepositryPattern.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core.models
{
    public class OrderProduct :productDto
    {
        [Key]
        public int Id { get; set; }
    
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public int Quantity { get; set; }
    }
}
