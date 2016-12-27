﻿using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class NguyenLieuRepository : IGenericRepository<NGUYENLIEU>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<NGUYENLIEU> DbSet;

        public NguyenLieuRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<NGUYENLIEU>();
        }
        public async Task Add(NGUYENLIEU Entity)
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

        public async Task<NGUYENLIEU> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<NGUYENLIEU>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(NGUYENLIEU Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }

        public DbSet<NGUYENLIEU> GetList()
        {
            return DbSet;
        }
    }
}
