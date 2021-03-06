﻿using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace QuanLyNhaHang.Infrastructure
{
    public class PhanHoiRepository : IGenericRepository<PHANHOI>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<PHANHOI> DbSet;
        public PhanHoiRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<PHANHOI>();
        }
        public async Task Add(PHANHOI Entity, string nguoitao)
        {
            Entity.NguoiTao = nguoitao;
            Entity.NgayTao = DateTime.Now;
            Entity.TrangThai = "1";
            Entity.TrangThaiDuyet = "U";
            Context.Add(Entity);
            await Save();
        }

        private async Task Save()
        {
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var phanhoi = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(phanhoi);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<PHANHOI> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<PHANHOI>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(PHANHOI Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
        {
            if (trangthaiduyet == "A" && Entity.TrangThaiDuyet == "U")
            {
                Entity.NgayDuyet = DateTime.Now;
                Entity.NguoiDuyet = nguoiduyet;
            }
            Entity.TrangThaiDuyet = trangthaiduyet;
            Entity.TrangThai = trangthai;
            DbSet.Update(Entity);
            await Save();
        }

        public DbSet<PHANHOI> GetList()
        {
            return DbSet;
        }

        public void SetState(PHANHOI Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
