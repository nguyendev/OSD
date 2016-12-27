using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace QuanLyNhaHang.Infrastructure
{
    public class ThuChiRepository : IGenericRepository<THUCHI>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<THUCHI> DbSet;

        public ThuChiRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<THUCHI>();
        }
        public async Task Add(THUCHI Entity)
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
            var THUCHI = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(THUCHI);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<THUCHI> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<THUCHI>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(THUCHI Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }

        public DbSet<THUCHI> GetList()
        {
            return DbSet;
        }
    }
}
