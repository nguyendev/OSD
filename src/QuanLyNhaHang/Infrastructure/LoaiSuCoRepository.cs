using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class LoaiSuCoRepository : IGenericRepository<LOAISUCO>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<LOAISUCO> DbSet;
        public LoaiSuCoRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<LOAISUCO>();
        }
        public async Task Add(LOAISUCO Entity)
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
            var loaisuco = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(loaisuco);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<LOAISUCO> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<LOAISUCO>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(LOAISUCO Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }
    }
}
