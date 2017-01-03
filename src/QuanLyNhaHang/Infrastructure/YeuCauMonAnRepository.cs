using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class YeuCauMonAnRepository : IGenericRepository<YEUCAUMONAN>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<YEUCAUMONAN> DbSet;

        public YeuCauMonAnRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<YEUCAUMONAN>();
        }

        public async Task Add(YEUCAUMONAN Entity, string nguoitao)
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
            var yeucau = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(yeucau);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<YEUCAUMONAN> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<YEUCAUMONAN>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(YEUCAUMONAN Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
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

        public DbSet<YEUCAUMONAN> GetList()
        {
            return DbSet;
        }

        public void SetState(YEUCAUMONAN Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
