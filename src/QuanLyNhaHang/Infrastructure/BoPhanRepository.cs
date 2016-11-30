using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task Add(BOPHAN Entity)
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

        public async Task Update(BOPHAN Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }
    }
}
