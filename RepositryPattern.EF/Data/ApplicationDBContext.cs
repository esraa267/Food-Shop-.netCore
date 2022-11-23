using System;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositryPattern.Core.models;

namespace RepositryPattern.EF.Data
{
    public class ApplicationDBContext: IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<product> products { get; set; }
        public DbSet<order> orders { get; set; }    
        public DbSet<OrderProduct> orderProducts { get; set; }

    }
}
