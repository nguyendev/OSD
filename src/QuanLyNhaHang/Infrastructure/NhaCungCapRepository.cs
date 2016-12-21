﻿using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class NhaCungCapRepository:IGenericRepository<NHACUNGCAP>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<NHACUNGCAP> DbSet;

        public NhaCungCapRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<NHACUNGCAP>();
        }
        public async Task Add(NHACUNGCAP Entity)
        {
            Context.Add(Entity);
            await Save();
        }

        public async Task<NHACUNGCAP> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }
        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<List<NHACUNGCAP>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(NHACUNGCAP Entity)
        {
            DbSet.Update(Entity);
            await Save();
        }

        public async Task Delete(int id)
        {
            var nhacungcap = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(nhacungcap);
            await Save();
        }

        private async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}