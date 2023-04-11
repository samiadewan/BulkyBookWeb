using BulkyBookweb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookweb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //create connection with entity framework core
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
