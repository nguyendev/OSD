using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Data;
using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class PhieuChiRepository : IGenericRepository<PHIEUCHI>
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<PHIEUCHI> DbSet;
        private readonly HoaDonNhapHangRepository hoadonrep;
        private readonly NhaCungCapRepository nccrep;

        public PhieuChiRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<PHIEUCHI>();
            hoadonrep = new HoaDonNhapHangRepository(Context);
            nccrep = new NhaCungCapRepository(Context);

        }
        public async Task Add(PHIEUCHI Entity, string nguoitao)
        {
            var hoadon = hoadonrep.GetList().Where(c => c.MaHD == Entity.MaHD).SingleOrDefault();
            Entity.SoNo = (Convert.ToDouble(hoadon.ThanhTien) - Convert.ToDouble(Entity.ThanhTien)).ToString();
            var nhacungcap = nccrep.GetList().Where(c => c.MaNCC == hoadon.MaNCC).SingleOrDefault();
            nccrep.SetState(nhacungcap, EntityState.Modified);
            nhacungcap.SoNo = (Convert.ToDouble(nhacungcap.SoNo) + Convert.ToDouble(Entity.SoNo)).ToString();
            await nccrep.Update(nhacungcap);
            Entity.LaPhieuThu = false;
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
            var phieuchi = await DbSet.SingleOrDefaultAsync(m => m.Id == id);
            var hoadon = hoadonrep.GetList().Where(c => c.MaHD == phieuchi.MaHD).SingleOrDefault();
            phieuchi.SoNo = (Convert.ToDouble(hoadon.ThanhTien) - Convert.ToDouble(phieuchi.ThanhTien)).ToString();
            var nhacungcap = nccrep.GetList().Where(c => c.MaNCC == hoadon.MaNCC).SingleOrDefault();
            nccrep.SetState(nhacungcap, EntityState.Modified);
            nhacungcap.SoNo = (Convert.ToDouble(nhacungcap.SoNo) + Convert.ToDouble(phieuchi.SoNo)).ToString();
            await nccrep.Update(nhacungcap);
            DbSet.Remove(phieuchi);
            await Save();
        }

        public bool Exists(int id)
        {
            return DbSet.Any(c => c.Id == id);
        }

        public async Task<PHIEUCHI> Get(int? id)
        {
            return await DbSet.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<PHIEUCHI>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(PHIEUCHI Entity, string trangthaiduyet = "U", string trangthai = "1", string nguoiduyet = null)
        {
            var hoadon = hoadonrep.GetList().Where(c => c.MaHD == Entity.MaHD).SingleOrDefault();
            Entity.SoNo = (Convert.ToDouble(hoadon.ThanhTien) - Convert.ToDouble(Entity.ThanhTien)).ToString();
            var nhacungcap = nccrep.GetList().Where(c => c.MaNCC == hoadon.MaNCC).SingleOrDefault();
            nccrep.SetState(nhacungcap, EntityState.Modified);
            nhacungcap.SoNo = (Convert.ToDouble(nhacungcap.SoNo) + Convert.ToDouble(Entity.SoNo)).ToString();
            await nccrep.Update(nhacungcap);
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

        public DbSet<PHIEUCHI> GetList()
        {
            return DbSet;
        }

        public void SetState(PHIEUCHI Entity, EntityState state)
        {
            Context.Entry(Entity).State = state;
        }
    }
}
