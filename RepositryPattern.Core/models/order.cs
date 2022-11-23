
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core.models
{
    public class order
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }

     
    }

    
}
