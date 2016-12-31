using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class PhieuChiRepository : IGenericRepository<PHIEUCHI>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<PHIEUCHI> DbSet;

        public PhieuChiRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<PHIEUCHI>();
        }
        public async Task Add(PHIEUCHI Entity, string nguoitao)
        {
            Entity.LaPhieuThu = false;
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
            var phieuchi = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(phieuchi);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<PHIEUCHI> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<PHIEUCHI>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(PHIEUCHI Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
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

        public DbSet<PHIEUCHI> GetList()
        {
            return DbSet;
        }

        public void SetState(PHIEUCHI Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
