using Microsoft.EntityFrameworkCore;
using RazorPagesCrash.Model;

namespace RazorPagesCrash.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
    }
}
