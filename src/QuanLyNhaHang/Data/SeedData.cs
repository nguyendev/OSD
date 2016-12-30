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
                   MaBienBan = "asjd",
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
    }
}
