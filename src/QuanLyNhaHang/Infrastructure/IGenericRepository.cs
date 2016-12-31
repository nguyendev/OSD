using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int? id);
        bool Exists(int id);
        Task<List<T>> GetAll();
        Task Add(T Entity, string nguoitao);
        Task Update(T Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null);

        Task Delete(int id);

        DbSet<T> GetList();

        void SetState(T Entity, EntityState state);
    }
}
