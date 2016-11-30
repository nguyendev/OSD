using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class SoThuChiRepository : IGenericRepository<SOTHUCHI>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<SOTHUCHI> DbSet;

        public SoThuChiRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<SOTHUCHI>();
        }
        public async Task Add(SOTHUCHI Entity)
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
            var sothuchi = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(sothuchi);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<SOTHUCHI> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<SOTHUCHI>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(SOTHUCHI Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }
    }
}
