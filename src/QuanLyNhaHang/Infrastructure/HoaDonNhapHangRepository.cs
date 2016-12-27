using System.Collections.Generic;
using System.Threading.Tasks;
using QuanLyNhaHang.Models;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using System.Linq;
using System;

namespace QuanLyNhaHang.Infrastructure
{
    public class HoaDonNhapHangRepository : IGenericRepository<HOADONNHAPHANG>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<HOADONNHAPHANG> DbSet;

        public HoaDonNhapHangRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<HOADONNHAPHANG>();
        }
        public async Task Add(HOADONNHAPHANG Entity)
        {
            Context.Add(Entity);
            await Save();
        }

        private async Task Save()
        {
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var hoadon = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(hoadon);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<HOADONNHAPHANG> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<HOADONNHAPHANG>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(HOADONNHAPHANG Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }

        public DbSet<HOADONNHAPHANG> GetList()
        {
            return DbSet;
        }
    }
}
