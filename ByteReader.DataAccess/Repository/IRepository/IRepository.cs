﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ByteReader.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class 
    {
        
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null); 
        void Add(T item);

        void Remove(T item);
        void RemoveRange(IEnumerable<T> item);


    }


}
