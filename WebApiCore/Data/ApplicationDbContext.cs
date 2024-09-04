using Microsoft.EntityFrameworkCore;
using WebApiCore.Models;

namespace WebApiCore.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }
        
        public DbSet<Emp> Employees { get; set; }
    }
}
