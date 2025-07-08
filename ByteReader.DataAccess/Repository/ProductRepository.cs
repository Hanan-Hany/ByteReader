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
             var objFromDB = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDB != null)
            {
                objFromDB.Title = obj.Title;
                objFromDB.ISBN = obj.ISBN;
                objFromDB.Author = obj.Author;
                objFromDB.ListPrice = obj.ListPrice;
                objFromDB.Price50 = obj.Price50;
                objFromDB.Price100 = obj.Price100;
                objFromDB.Description = obj.Description;
                objFromDB.Price = obj.Price;

                objFromDB.CategoryId = obj.CategoryId;
                if (obj.ImageUrl != null)
                {
                    objFromDB.ImageUrl = obj.ImageUrl;
                }
         }  }
    }
}
