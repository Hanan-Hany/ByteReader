using Luky_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Luky_Web.Data
{
    public class ApplicaionDbContext: DbContext
    {
        public ApplicaionDbContext(DbContextOptions <ApplicaionDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
