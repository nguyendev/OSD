using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class NhapHangRepository : IGenericRepository<NHAPHANG>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<NHAPHANG> DbSet;

        public NhapHangRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<NHAPHANG>();
        }
        public async Task Add(NHAPHANG Entity)
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
            var nhaphang = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(nhaphang);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<NHAPHANG> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<NHAPHANG>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(NHAPHANG Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }
    }
}
