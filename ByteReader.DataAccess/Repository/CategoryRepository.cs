using ByteReader.DataAccess.Data;
using ByteReader.DataAccess.Repository.IRepository;
using ByteReader.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ByteReader.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicaionDbContext _db;

        public CategoryRepository(ApplicaionDbContext db) : base(db)
        {
            _db = db;

        }

       
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
