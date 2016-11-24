using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class NhanVienRepository : IGenericRepository<NHANVIEN>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<NHANVIEN> DbSet;

        public NhanVienRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<NHANVIEN>();
        }
        public async Task Add(NHANVIEN Entity)
        {
            Context.Add(Entity);
            await Save();
        }

        public async Task<NHANVIEN> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }
        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<List<NHANVIEN>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(NHANVIEN Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }

        public async Task Delete(int id)
        {
            var nhanVien = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(nhanVien);
            await Save();          
        }

        private async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}
