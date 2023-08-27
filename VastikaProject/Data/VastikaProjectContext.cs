using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VastikaProject.Models;

namespace VastikaProject.Data
{
    public class VastikaProjectContext : DbContext
    {
        public VastikaProjectContext (DbContextOptions<VastikaProjectContext> options)
            : base(options)
        {
        }

        public DbSet<VastikaProject.Models.Customers> Customers { get; set; } = default!;
    }
}
