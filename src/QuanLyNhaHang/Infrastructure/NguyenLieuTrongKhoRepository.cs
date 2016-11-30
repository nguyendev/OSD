﻿using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class NguyenLieuTrongKhoRepository : IGenericRepository<NGUYENLIEUTRONGKHO>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<NGUYENLIEUTRONGKHO> DbSet;

        public NguyenLieuTrongKhoRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<NGUYENLIEUTRONGKHO>();
        }
        public async Task Add(NGUYENLIEUTRONGKHO Entity)
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
            var nguyenlieu = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(nguyenlieu);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<NGUYENLIEUTRONGKHO> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<NGUYENLIEUTRONGKHO>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(NGUYENLIEUTRONGKHO Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }
    }
}
