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
        // T - Category
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter); 
        void Add(T item);

        void Remove(T item);
        void RemoveRange(IEnumerable<T> item);


    }


}
