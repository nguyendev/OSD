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

        public async Task Add(YEUCAUMONAN Entity)
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

        public async Task Update(YEUCAUMONAN Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }

        public DbSet<YEUCAUMONAN> GetList()
        {
            return DbSet;
        }
    }
}
