
using ByteReader.Models;
using ByteReader.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ByteReader.DataAccess.Data
{
    public class ApplicaionDbContext: DbContext
    {
        public ApplicaionDbContext(DbContextOptions <ApplicaionDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
