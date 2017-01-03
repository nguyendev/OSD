﻿using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace QuanLyNhaHang.Infrastructure
{
    public class DatBanRepository : IGenericRepository<DATBAN>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<DATBAN> DbSet;

        public DatBanRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<DATBAN>();
        }
        public async Task Add(DATBAN Entity, string nguoitao)
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
            var datban = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(datban);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<DATBAN> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<DATBAN>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(DATBAN Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
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

        public DbSet<DATBAN> GetList()
        {
            return DbSet;
        }

        public void SetState(DATBAN Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
