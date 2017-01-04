using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Data
{
    public class SeedData {
        public static async Task CreateExampleBienbansuco(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                 serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.BIENBANSUCO.Any())
                {
                    return;   // DB has been seeded
                }
                context.BIENBANSUCO.AddRange(
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "1",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "2",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "002",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "3",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "003",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "4",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "004",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "5",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "005",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "6",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "7",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "8",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "9",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "10",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "11",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "12",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "13",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "14",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "15",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "16",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 },
                 new BIENBANSUCO
                 {
                     HuongGiaiQuyet = "ahsjdkfajksd",
                     MaBienBan = "17",
                     NgayDuyet = DateTime.Now,
                     ThoiGian = DateTime.Now.ToLocalTime().ToString(),
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     MaNV = "1",
                     MaLoaiSuCo = "001",
                     NgayTao = DateTime.Now,
                     NguyenNhan = "asdfds",
                     GhiChu = "ahsdjfka",

                 }
                );
                await context.SaveChangesAsync();
            }
        }
        public static async Task CreateExampleBophan(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                 serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.BOPHAN.Any())
                {
                    return;   // DB has been seeded
                }
                context.BOPHAN.AddRange(
                 new BOPHAN
                 {
                     MaBP = "001",
                     TenBP = "Nhà bếp",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "Test",

                 },
                 new BOPHAN
                 {
                     MaBP = "002",
                     TenBP = "Kế toán",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = " ",

                 },
                 new BOPHAN
                 {
                     MaBP = "003",
                     TenBP = "Phục vụ",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = " ",

                 },
                 new BOPHAN
                 {
                     MaBP = "004",
                     TenBP = "Giám đốc",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,

                 }
                );
                await context.SaveChangesAsync();
            }
        }
        public static async Task CreateExampleDatban(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                 serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.DATBAN.Any())
                {
                    return;   // DB has been seeded
                }
                context.DATBAN.AddRange(
                 new DATBAN
                 {
                     Gio = "10:00 AM",
                     HoTen = "Nguyen Van A",
                     Ngay = "2016-12-29",
                     SoDT = "0968784717",
                     SoNguoi = "3",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",

                 },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-12-30",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",

                  },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-01-01",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",

                  },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-01-02",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",

                  },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-01-02",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",

                  },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-01-03",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",
                  },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-01-02",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",
                  }
                );
                await context.SaveChangesAsync();
            }
        }
        public static async Task CreateExample(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                 serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.DATBAN.Any())
                {
                    return;   // DB has been seeded
                }
                context.DATBAN.AddRange(
                 new DATBAN
                 {
                     Gio = "10:00 AM",
                     HoTen = "Nguyen Van A",
                     Ngay = "2016-12-29",
                     SoDT = "0968784717",
                     SoNguoi = "3",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",

                 },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-12-30",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",

                  },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-01-01",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",

                  },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-01-02",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",

                  },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-01-02",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",

                  },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-01-03",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",
                  },
                  new DATBAN
                  {
                      Gio = "10:00 AM",
                      HoTen = "Nguyen Van A",
                      Ngay = "2016-01-02",
                      SoDT = "0968784717",
                      SoNguoi = "3",
                      NgayDuyet = DateTime.Now,
                      TrangThai = "1",
                      TrangThaiDuyet = "A",
                      NgayTao = DateTime.Now,
                      GhiChu = "ahsdjfka",
                  }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
