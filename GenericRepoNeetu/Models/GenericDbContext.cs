using Microsoft.EntityFrameworkCore;
using GenericRepoNeetu.Models;
namespace GenericRepoNeetu.Models
{
    public class GenericDbContext:DbContext
    {
        public GenericDbContext(DbContextOptions<GenericDbContext> options):base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
