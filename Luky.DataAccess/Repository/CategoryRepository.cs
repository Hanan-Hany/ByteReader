using Luky.DataAccess.Data;
using Luky.DataAccess.Repository.IRepository;
using Luky.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Luky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicaionDbContext _db;

        public CategoryRepository(ApplicaionDbContext db) : base(db)
        {
            {
                _db = db;

            }


        }

        public void save()
        {
           _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
