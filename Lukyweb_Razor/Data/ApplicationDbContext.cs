using Lukyweb_Razor.Model;
using Microsoft.EntityFrameworkCore;

namespace Lukyweb_Razor.Data
{
    public class ApplicaionDbContext : DbContext
    {
        public ApplicaionDbContext(DbContextOptions<ApplicaionDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public object Category { get; internal set; }
    }
}
