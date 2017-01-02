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
                     MaBP = "1",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",

                 },
                 new BOPHAN
                 {
                     MaBP = "2",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",

                 },
                 new BOPHAN
                 {
                     MaBP = "3",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",

                 },
                 new BOPHAN
                 {
                     MaBP = "4",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",

                 },
                 new BOPHAN
                 {
                     MaBP = "5",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",
                 },
                 new BOPHAN
                 {
                     MaBP = "6",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",

                 },
                 new BOPHAN
                 {
                     MaBP = "8",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",

                 },
                 new BOPHAN
                 {
                     MaBP = "7",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",

                 },
                 new BOPHAN
                 {
                     MaBP = "9",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",

                 },
                 new BOPHAN
                 {
                     MaBP = "10",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",
                 },
                 new BOPHAN
                 {
                     MaBP = "11",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",
                 },
                 new BOPHAN
                 {
                     MaBP = "12",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",

                 },
                 new BOPHAN
                 {
                     MaBP = "13",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",
                 },
                 new BOPHAN
                 {
                     MaBP = "14",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",
                 },
                 new BOPHAN
                 {
                     MaBP = "15",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",
                 },
                 new BOPHAN
                 {
                     MaBP = "16",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
                     NgayDuyet = DateTime.Now,
                     TrangThai = "1",
                     TrangThaiDuyet = "A",
                     NgayTao = DateTime.Now,
                     GhiChu = "ahsdjfka",
                 },
                 new BOPHAN
                 {
                     MaBP = "17",
                     TenBP = "ahsjdkfajksd",
                     MaTruongBP = "1",
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
