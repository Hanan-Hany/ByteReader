using ByteReader.DataAccess.Data;
using ByteReader.DataAccess.Repository.IRepository;
using ByteReader.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteReader.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private readonly ApplicaionDbContext _db;

        public ProductRepository(ApplicaionDbContext db) : base(db)
        {
            _db = db;

        }
        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
