﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Linq;

namespace QuanLyNhaHang.Infrastructure
{
    public class ThietHaiRepository : IGenericRepository<THIETHAI>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<THIETHAI> DbSet;

        public ThietHaiRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<THIETHAI>();
        }

        public async Task Add(THIETHAI Entity)
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
            var thiethai = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(thiethai);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<THIETHAI> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<THIETHAI>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(THIETHAI Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }

        public DbSet<THIETHAI> GetList()
        {
            return DbSet;
        }
    }
}
