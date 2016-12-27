using System.Collections.Generic;
using System.Threading.Tasks;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace QuanLyNhaHang.Infrastructure
{
    public class MonAnRepository : IGenericRepository<MONAN>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<MONAN> DbSet;

        public MonAnRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<MONAN>();
        }
        public async Task Add(MONAN Entity)
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
            var monan = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(monan);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<MONAN> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<MONAN>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(MONAN Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }

        public DbSet<MONAN> GetList()
        {
            return DbSet;
        }
    }
}
