
using Microsoft.EntityFrameworkCore;

namespace VastikaProject.DataAccessLayer.DataContext;

public class DbDataContext : DbContext
{
    public DbDataContext(DbContextOptions<DbDataContext> options) : base(options){ }
    
    

}
