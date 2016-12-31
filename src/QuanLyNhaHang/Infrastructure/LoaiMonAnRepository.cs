using System.Collections.Generic;
using System.Threading.Tasks;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace QuanLyNhaHang.Infrastructure
{
    public class LoaiMonAnRepository : IGenericRepository<LOAIMONAN>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<LOAIMONAN> DbSet;

        public LoaiMonAnRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<LOAIMONAN>();
        }
        public async Task Add(LOAIMONAN Entity, string nguoitao)
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
            var loaimonan = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(loaimonan);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<LOAIMONAN> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<LOAIMONAN>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(LOAIMONAN Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
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

        public DbSet<LOAIMONAN> GetList()
        {
            return DbSet;
        }

        public void SetState(LOAIMONAN Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
