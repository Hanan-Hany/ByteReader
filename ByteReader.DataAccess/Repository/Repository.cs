﻿using ByteReader.DataAccess.Data;
using ByteReader.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ByteReader.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicaionDbContext _db;
        internal DbSet<T> dbSet;   
        public Repository(ApplicaionDbContext db)
        {
            _db = db;
            this.dbSet=_db.Set<T>();
            _db.Products.Include(u => u.category).Include(u => u.CategoryId);
        }
        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter , string? includeProperties = null)
        {
            IQueryable<T> query = dbSet.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T item)
        { 
            dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> item)
        {
           dbSet.RemoveRange(item);
        }
    }
}
