using System.Collections.Generic;
using System.Threading.Tasks;
using QuanLyNhaHang.Models;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using System.Linq;
using System;

namespace QuanLyNhaHang.Infrastructure
{
    public class HoaDonNhapHangRepository : IGenericRepository<HOADONNHAPHANG>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<HOADONNHAPHANG> DbSet;

        public HoaDonNhapHangRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<HOADONNHAPHANG>();
        }
        public async Task Add(HOADONNHAPHANG Entity, string nguoitao)
        {
            YeuCauNhapHangRepository yeucaurep = new YeuCauNhapHangRepository(Context);
            NguyenLieuRepository nccrep = new NguyenLieuRepository(Context);
            var yeucaunhaphang = yeucaurep.GetList().Where(c => c.MaYeuCau == Entity.MaYeuCau).SingleOrDefault();
            var nguyenlieu = nccrep.GetList().Where(c => c.MaNL == yeucaunhaphang.MaNL).SingleOrDefault();
            Entity.ThanhTien = (yeucaunhaphang.SoLuong * Convert.ToDouble(nguyenlieu.Gia)).ToString(); 
            Entity.NguoiTao = nguoitao;
            Entity.NgayTao = DateTime.Now;
            Entity.TrangThai = "1";
            Entity.TrangThaiDuyet = "U";
            Entity.MaNCC = yeucaunhaphang.MaNCC;
            Context.Add(Entity);
            await Save();
        }

        private async Task Save()
        {
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var hoadon = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(hoadon);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<HOADONNHAPHANG> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<HOADONNHAPHANG>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(HOADONNHAPHANG Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
        {
            YeuCauNhapHangRepository yeucaurep = new YeuCauNhapHangRepository(Context);
            NguyenLieuRepository nccrep = new NguyenLieuRepository(Context);
            var yeucaunhaphang = yeucaurep.GetList().Where(c => c.MaYeuCau == Entity.MaYeuCau).SingleOrDefault();
            var nguyenlieu = nccrep.GetList().Where(c => c.MaNL == yeucaunhaphang.MaNL).SingleOrDefault();
            Entity.ThanhTien = (yeucaunhaphang.SoLuong * Convert.ToDouble(nguyenlieu.Gia)).ToString();
            if (trangthaiduyet == "A" && Entity.TrangThaiDuyet == "U")
            {
                Entity.NgayDuyet = DateTime.Now;
                Entity.NguoiDuyet = nguoiduyet;
            }
            Entity.TrangThaiDuyet = trangthaiduyet;
            Entity.TrangThai = trangthai;
            Entity.MaNCC = yeucaunhaphang.MaNCC;
            DbSet.Update(Entity);
            await Save();
        }

        public DbSet<HOADONNHAPHANG> GetList()
        {
            return DbSet;
        }

        public void SetState(HOADONNHAPHANG Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
