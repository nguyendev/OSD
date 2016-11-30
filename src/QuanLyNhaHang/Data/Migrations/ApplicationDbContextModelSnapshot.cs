using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuanLyNhaHang.Data;

namespace QuanLyNhaHang.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.AppUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("Qualifications");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.BIENBANSUCO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HuongGiaiQuyet");

                    b.Property<string>("LoaiSuCo");

                    b.Property<string>("MaBienBan");

                    b.Property<string>("NguoiChiuTrachNhiem");

                    b.Property<string>("NguyenNhan");

                    b.Property<int>("NhanVienId");

                    b.Property<string>("ThoiGian");

                    b.HasKey("Id");

                    b.HasIndex("NhanVienId");

                    b.ToTable("BIENBANSUCO");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.BlogBusiness", b =>
                {
                    b.Property<int>("BusinessId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessCode")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("BusinessId");

                    b.ToTable("BlogBusiness");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.BlogPermission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BlogBusinessesBusinessId");

                    b.Property<string>("BussinessCode")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("PermissionId");

                    b.HasIndex("BlogBusinessesBusinessId");

                    b.ToTable("BlogPermission");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.BOPHAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MaBP");

                    b.Property<string>("TenBP");

                    b.Property<int>("TruongBPId");

                    b.HasKey("Id");

                    b.ToTable("BOPHAN");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.CHEBIEN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LuongDung");

                    b.Property<int>("MonAnId");

                    b.Property<int>("NguyenLieuId");

                    b.HasKey("Id");

                    b.HasIndex("MonAnId");

                    b.HasIndex("NguyenLieuId");

                    b.ToTable("CHEBIEN");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.HOADONNHAPHANG", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NgayLap");

                    b.Property<int>("NhaCungCapId");

                    b.Property<int>("NhanVienId");

                    b.Property<string>("SoHD");

                    b.Property<string>("ThanhTien");

                    b.Property<string>("ThoiGianNhap");

                    b.HasKey("Id");

                    b.HasIndex("NhaCungCapId");

                    b.HasIndex("NhanVienId");

                    b.ToTable("HOADONNHAHANG");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.LUOTKHACH", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MaLuot");

                    b.Property<int>("SoBan");

                    b.Property<string>("ThoiGianRa");

                    b.Property<string>("ThoiGianVao");

                    b.HasKey("Id");

                    b.ToTable("LUOTKHACH");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.MONAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gia");

                    b.Property<string>("MaMon");

                    b.Property<string>("TenMon");

                    b.HasKey("Id");

                    b.ToTable("MONAN");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NGUYENLIEU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DVT");

                    b.Property<string>("Gia");

                    b.Property<string>("MaNL");

                    b.Property<string>("TenNL");

                    b.Property<string>("XuatXu");

                    b.HasKey("Id");

                    b.ToTable("NGUYENLIEU");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NGUYENLIEUTRONGKHO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NguyenLieuId");

                    b.Property<int>("SoLuong");

                    b.Property<bool>("TinhTrang");

                    b.HasKey("Id");

                    b.HasIndex("NguyenLieuId");

                    b.ToTable("NGUYENLIEUTRONGKHO");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NHACUNGCAP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiaChi");

                    b.Property<string>("MaNCC");

                    b.Property<string>("SoDT");

                    b.Property<string>("SoNo");

                    b.Property<string>("TenNCC");

                    b.HasKey("Id");

                    b.ToTable("NHACUNGCAP");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NHANVIEN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoPhanId");

                    b.Property<string>("CMND");

                    b.Property<string>("DiaChi");

                    b.Property<string>("MaNV");

                    b.Property<int>("SoDT");

                    b.Property<string>("TenNV");

                    b.HasKey("Id");

                    b.HasIndex("BoPhanId")
                        .IsUnique();

                    b.ToTable("NHANVIEN");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NHAPHANG", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DonGia");

                    b.Property<int?>("HOADONNHAPHANGId");

                    b.Property<int>("HoaDonId");

                    b.Property<string>("MaNCC");

                    b.Property<string>("MaNL");

                    b.Property<string>("SoLuong");

                    b.HasKey("Id");

                    b.HasIndex("HOADONNHAPHANGId");

                    b.ToTable("NHAPHANG");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.PHIEUCHI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MaNCC");

                    b.Property<string>("MaNV");

                    b.Property<string>("MaPC");

                    b.Property<string>("NgayLap");

                    b.Property<int?>("SOTHUCHIId");

                    b.Property<string>("SoHD");

                    b.Property<string>("SoTienChi");

                    b.HasKey("Id");

                    b.HasIndex("SOTHUCHIId");

                    b.ToTable("PHIEUCHI");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.PHIEUTHU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KhuyenMai");

                    b.Property<string>("MaLuot");

                    b.Property<string>("MaNV");

                    b.Property<string>("MaPT");

                    b.Property<string>("NgayLap");

                    b.Property<string>("PhiDichVuKhac");

                    b.Property<int?>("SOTHUCHIId");

                    b.Property<string>("TienHang");

                    b.Property<string>("TongTien");

                    b.Property<string>("VAT");

                    b.HasKey("Id");

                    b.HasIndex("SOTHUCHIId");

                    b.ToTable("PHIEUTHU");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.SOTHUCHI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MaPC");

                    b.Property<string>("MaPT");

                    b.Property<string>("Ngay");

                    b.HasKey("Id");

                    b.ToTable("SOTHUCHI");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.THIETHAI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BIENBANSUCOId");

                    b.Property<int>("BienBanId");

                    b.Property<string>("DVT");

                    b.Property<string>("DonGia");

                    b.Property<int>("SoLuong");

                    b.Property<string>("Ten");

                    b.Property<string>("ThanhTien");

                    b.HasKey("Id");

                    b.HasIndex("BIENBANSUCOId");

                    b.ToTable("THIETHAI");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.YEUCAUMONAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LuotKhachId");

                    b.Property<int>("MonAnId");

                    b.Property<int>("SoLuong");

                    b.HasKey("Id");

                    b.HasIndex("LuotKhachId");

                    b.HasIndex("MonAnId");

                    b.ToTable("YEUCAUMONAN");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.AppUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.AppUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuanLyNhaHang.Models.AppUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.BIENBANSUCO", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.NHANVIEN", "NHANVIEN")
                        .WithMany()
                        .HasForeignKey("NhanVienId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.BlogPermission", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.BlogBusiness", "BlogBusinesses")
                        .WithMany("BlogPermissions")
                        .HasForeignKey("BlogBusinessesBusinessId");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.CHEBIEN", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.MONAN", "MONAN")
                        .WithMany()
                        .HasForeignKey("MonAnId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuanLyNhaHang.Models.NGUYENLIEU", "NGUYENLIEU")
                        .WithMany()
                        .HasForeignKey("NguyenLieuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.HOADONNHAPHANG", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.NHACUNGCAP", "NHACUNGCAP")
                        .WithMany()
                        .HasForeignKey("NhaCungCapId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuanLyNhaHang.Models.NHANVIEN", "NHANVIEN")
                        .WithMany()
                        .HasForeignKey("NhanVienId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NGUYENLIEUTRONGKHO", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.NGUYENLIEU", "NGUYENLIEU")
                        .WithMany()
                        .HasForeignKey("NguyenLieuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NHANVIEN", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.BOPHAN", "BOPHAN")
                        .WithOne("NHANVIEN")
                        .HasForeignKey("QuanLyNhaHang.Models.NHANVIEN", "BoPhanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NHAPHANG", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.HOADONNHAPHANG", "HOADONNHAPHANG")
                        .WithMany("NHAPHANG")
                        .HasForeignKey("HOADONNHAPHANGId");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.PHIEUCHI", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.SOTHUCHI", "SOTHUCHI")
                        .WithMany()
                        .HasForeignKey("SOTHUCHIId");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.PHIEUTHU", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.SOTHUCHI", "SOTHUCHI")
                        .WithMany()
                        .HasForeignKey("SOTHUCHIId");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.THIETHAI", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.BIENBANSUCO", "BIENBANSUCO")
                        .WithMany()
                        .HasForeignKey("BIENBANSUCOId");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.YEUCAUMONAN", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.LUOTKHACH", "LUOTKHACH")
                        .WithMany()
                        .HasForeignKey("LuotKhachId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuanLyNhaHang.Models.MONAN", "MONAN")
                        .WithMany()
                        .HasForeignKey("MonAnId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
