using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace QuanLyNhaHang.Infrastructure
{
    public class BienBanSuCoRepository : IGenericRepository<BIENBANSUCO>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<BIENBANSUCO> DbSet;

        public BienBanSuCoRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<BIENBANSUCO>();
        }
        public async Task Add(BIENBANSUCO Entity)
        {
            Context.Add(Entity);
            await Save();
        }

        public async Task<BIENBANSUCO> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }
        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<List<BIENBANSUCO>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(BIENBANSUCO Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }

        public async Task Delete(int id)
        {
            var bienban = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(bienban);
            await Save();
        }

        private async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}
