using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class PhieuThuRepository : IGenericRepository<PHIEUTHU>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<PHIEUTHU> DbSet;
        public PhieuThuRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<PHIEUTHU>();
        }
        public async Task Add(PHIEUTHU Entity)
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
            var phieuthu = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(phieuthu);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<PHIEUTHU> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<PHIEUTHU>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(PHIEUTHU Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }
    }
}
