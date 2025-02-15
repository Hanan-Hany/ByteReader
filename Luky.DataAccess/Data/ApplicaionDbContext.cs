using Luky.Models;
using Microsoft.EntityFrameworkCore;

namespace Luky.DataAccess.Data
{
    public class ApplicaionDbContext: DbContext
    {
        public ApplicaionDbContext(DbContextOptions <ApplicaionDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
