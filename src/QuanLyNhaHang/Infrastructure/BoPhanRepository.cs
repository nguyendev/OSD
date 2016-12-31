using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace QuanLyNhaHang.Infrastructure
{
    public class BoPhanRepository : IGenericRepository<BOPHAN>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<BOPHAN> DbSet;

        public BoPhanRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<BOPHAN>();
        }
        public async Task Add(BOPHAN Entity, string nguoitao)
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
            var bophan = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(bophan);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<BOPHAN> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<BOPHAN>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(BOPHAN Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
        {
            Entity.NgayTao = DateTime.Now;
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

        public DbSet<BOPHAN> GetList()
        {
            return DbSet;
        }

        public void SetState(BOPHAN Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
