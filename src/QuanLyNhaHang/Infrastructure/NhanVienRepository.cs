﻿using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

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
        public async Task Add(NHANVIEN Entity, string nguoitao)
        {
            Entity.NguoiTao = nguoitao;
            Entity.NgayTao = DateTime.Now;
            Entity.TrangThai = "1";
            Entity.TrangThaiDuyet = "U";
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

        public async Task Update(NHANVIEN Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
        {
            Entity.NgayTao = DateTime.Now;
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

        public async Task Delete(int id)
        {
            var nhanvien = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(nhanvien);
            await Save();          
        }

        private async Task Save()
        {
            await Context.SaveChangesAsync();
        }

        public DbSet<NHANVIEN> GetList()
        {
            return DbSet;
        }

        public void SetState(NHANVIEN Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
