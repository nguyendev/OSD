using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace QuanLyNhaHang.Infrastructure
{
    public class PhieuThuRepository : IGenericRepository<PHIEUTHU>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<PHIEUTHU> DbSet;
        private readonly YeuCauMonAnRepository yeucaurep;
        private readonly MonAnRepository monanrep;
        public PhieuThuRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<PHIEUTHU>();
            monanrep = new MonAnRepository(context);
            yeucaurep = new YeuCauMonAnRepository(context);
        }
        public async Task Add(PHIEUTHU Entity, string nguoitao)
        {
            Entity.TienHang = "0";
            var collection = yeucaurep.GetList().Where(c => c.TrangThai == "1" && c.TrangThaiDuyet == "A"
            && c.MaLuot == Entity.MaLuot).ToList();
            foreach (var item in collection)
            {
                var monan = monanrep.GetList().Where(c => c.TrangThai == "1" && c.TrangThaiDuyet == "A"
                && c.MaMon == item.MaMon).SingleOrDefault();
                Entity.TienHang = (float.Parse(Entity.ThanhTien) + float.Parse(monan.Gia)).ToString();
            }
            double thanhtien = float.Parse(Entity.TienHang);
            if (Entity.PhiDichVuKhac != null)
                thanhtien += float.Parse(Entity.PhiDichVuKhac);
            if (Entity.KhuyenMai != null)
                thanhtien *= (1 - (float.Parse(Entity.KhuyenMai) / 100));
            if (Entity.VAT != null)
                thanhtien += thanhtien * (float.Parse(Entity.VAT) / 100);
            Entity.ThanhTien = thanhtien.ToString();   
            Entity.LaPhieuThu = true;
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
            var phieuthu = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            DbSet.Remove(phieuthu);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<PHIEUTHU> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<PHIEUTHU>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(PHIEUTHU Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
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

        public DbSet<PHIEUTHU> GetList()
        {
            return DbSet;
        }

        public void SetState(PHIEUTHU Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
