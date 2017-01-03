using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace QuanLyNhaHang.Infrastructure
{
    public class LuotKhachRepository : IGenericRepository<LUOTKHACH>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<LUOTKHACH> DbSet;

        public LuotKhachRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<LUOTKHACH>();
        }
        public async Task Add(LUOTKHACH Entity, string nguoitao)
        {
            Entity.NguoiTao = nguoitao;
            Entity.NgayTao = DateTime.Now;
            Entity.TrangThai = "1";
            Entity.TrangThaiDuyet = "U";
            Context.Add(Entity);
            await Save();
        }

        private async Task Save()
        {
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var luotkhach = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(luotkhach);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<LUOTKHACH> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<LUOTKHACH>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(LUOTKHACH Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
        {
            if (trangthaiduyet == "A" && Entity.TrangThaiDuyet == "U")
            {
                Entity.NgayDuyet = DateTime.Now;
                Entity.NguoiDuyet = nguoiduyet;
            }
            Entity.TrangThaiDuyet = trangthaiduyet;
            Entity.TrangThai = trangthai;
            DbSet.Update(Entity);
            await Save();
        }

        public DbSet<LUOTKHACH> GetList()
        {
            return DbSet;
        }

        public void SetState(LUOTKHACH Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
