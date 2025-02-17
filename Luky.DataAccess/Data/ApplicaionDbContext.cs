
using ByteReader.Models;
using Microsoft.EntityFrameworkCore;

namespace ByteReader.DataAccess.Data
{
    public class ApplicaionDbContext: DbContext
    {
        public ApplicaionDbContext(DbContextOptions <ApplicaionDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
