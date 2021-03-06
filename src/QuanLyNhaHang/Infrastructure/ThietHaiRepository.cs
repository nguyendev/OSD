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

        public async Task Add(THIETHAI Entity, string nguoitao)
        {
            Entity.ThanhTien = (Convert.ToDouble(Entity.DonGia) * Entity.SoLuong).ToString();
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

        public async Task Update(THIETHAI Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
        {
            Entity.ThanhTien = (Convert.ToDouble(Entity.DonGia) * Entity.SoLuong).ToString();
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

        public DbSet<THIETHAI> GetList()
        {
            return DbSet;
        }

        public void SetState(THIETHAI Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
