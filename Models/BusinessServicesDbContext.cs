using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Models
{
    public class BusinessServicesDbContext : DbContext
    {
        public BusinessServicesDbContext(DbContextOptions<BusinessServicesDbContext> options) : base(options)
        {}
        public DbSet<BusinessServiceModel> BusinessServices { get; set; }

        
    }
}
