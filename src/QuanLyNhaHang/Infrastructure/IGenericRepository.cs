using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    interface IGenericRepository<T>
    {
        T Get(int id);
        IQueryable<T> GetAll();
        void Add(T Entity);
        void Update(T Entity);   
    }
}
