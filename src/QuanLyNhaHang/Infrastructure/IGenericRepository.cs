using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int? id);
        bool Exists(int id);
        Task<List<T>> GetAll();
        Task Add(T Entity);
        Task Update(T Entity);

        Task Delete(int id);

        DbSet<T> GetList();
    }
}
