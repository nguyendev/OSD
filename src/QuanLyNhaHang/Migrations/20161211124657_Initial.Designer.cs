using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuanLyNhaHang.Data;

namespace QuanLyNhaHang.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161211124657_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BIENBANSUCO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HuongGiaiQuyet");

                    b.Property<string>("MaBienBan");

                    b.Property<string>("MaLSC");

                    b.Property<string>("MaNV");

                    b.Property<string>("NguyenNhan");

                    b.Property<string>("ThoiGian");

                    b.HasKey("Id");

                    b.ToTable("BIENBANSUCO");
                });

            modelBuilder.Entity("BOPHAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MaBP");

                    b.Property<int?>("MaTruongBP");

                    b.Property<string>("TenBP");

                    b.HasKey("Id");

                    b.ToTable("BOPHAN");
                });

            modelBuilder.Entity("CHEBIEN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LuongDung");

                    b.Property<string>("MaMon");

                    b.Property<string>("MaNL");

                    b.HasKey("Id");

                    b.ToTable("CHEBIEN");
                });

            modelBuilder.Entity("DATBAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gio");

                    b.Property<string>("HoTen");

                    b.Property<string>("Ngay");

                    b.Property<string>("SoDT");

                    b.Property<string>("SoNguoi");

                    b.HasKey("Id");

                    b.ToTable("DATBAN");
                });

            modelBuilder.Entity("HOADONNHAPHANG", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaNCC");

                    b.Property<int>("MaNV");

                    b.Property<string>("NgayLap");

                    b.Property<string>("SoHD");

                    b.Property<string>("ThanhTien");

                    b.Property<string>("ThoiGianNhap");

                    b.HasKey("Id");

                    b.ToTable("HOADONNHAHANG");
                });

            modelBuilder.Entity("LOAISUCO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaBoPhanXuLy");

                    b.Property<string>("MaLSC");

                    b.Property<string>("TenLSC");

                    b.HasKey("Id");

                    b.ToTable("LOAISUCO");
                });

            modelBuilder.Entity("LUOTKHACH", b =>
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

            modelBuilder.Entity("MONAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gia");

                    b.Property<string>("MaMon");

                    b.Property<string>("TenMon");

                    b.HasKey("Id");

                    b.ToTable("MONAN");
                });

            modelBuilder.Entity("NGUYENLIEU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DVT");

                    b.Property<string>("Gia");

                    b.Property<string>("MaNL");

                    b.Property<string>("TenNL");

                    b.HasKey("Id");

                    b.ToTable("NGUYENLIEU");
                });

            modelBuilder.Entity("NGUYENLIEUTRONGKHO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaNL");

                    b.Property<int>("SoLuong");

                    b.Property<bool>("TinhTrang");

                    b.HasKey("Id");

                    b.ToTable("NGUYENLIEUTRONGKHO");
                });

            modelBuilder.Entity("NHACUNGCAP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiaChi");

                    b.Property<string>("MaNCC");

                    b.Property<string>("SoDT");

                    b.Property<string>("SoNo");

                    b.Property<string>("SoTienNo");

                    b.Property<string>("TenNCC");

                    b.HasKey("Id");

                    b.ToTable("NHACUNGCAP");
                });

            modelBuilder.Entity("NHANVIEN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CMND");

                    b.Property<string>("DiaChi");

                    b.Property<int>("MaBP");

                    b.Property<string>("MaNV");

                    b.Property<int>("SoDT");

                    b.Property<string>("TenNV");

                    b.HasKey("Id");

                    b.ToTable("NHANVIEN");
                });

            modelBuilder.Entity("PHANHOI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NoiDung");

                    b.Property<string>("TenNguoiPH");

                    b.HasKey("Id");

                    b.ToTable("PHANHOI");
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

            modelBuilder.Entity("THIETHAI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DVT");

                    b.Property<string>("DonGia");

                    b.Property<int>("MaBienBan");

                    b.Property<int>("SoLuong");

                    b.Property<string>("Ten");

                    b.Property<string>("ThanhTien");

                    b.HasKey("Id");

                    b.ToTable("THIETHAI");
                });

            modelBuilder.Entity("THUCHI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("LaPhieuThu");

                    b.Property<string>("NgayLap");

                    b.Property<string>("SoTien");

                    b.HasKey("Id");

                    b.ToTable("THUCHI");

                    b.HasDiscriminator<string>("Discriminator").HasValue("THUCHI");
                });

            modelBuilder.Entity("YEUCAUMONAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaLuot");

                    b.Property<int>("MaMon");

                    b.Property<int>("SoLuong");

                    b.HasKey("Id");

                    b.ToTable("YEUCAUMONAN");
                });

            modelBuilder.Entity("YEUCAUNHAPHANG", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DonGia");

                    b.Property<int>("MaNCC");

                    b.Property<int>("MaNL");

                    b.Property<int>("SoHD");

                    b.Property<int>("SoLuong");

                    b.HasKey("Id");

                    b.ToTable("YEUCAUNHAPHANG");
                });

            modelBuilder.Entity("PHIEUCHI", b =>
                {
                    b.HasBaseType("THUCHI");

                    b.Property<int>("MaHoaDon");

                    b.Property<string>("MaPC");

                    b.Property<string>("SoNo");

                    b.Property<string>("SoTienChi");

                    b.ToTable("PHIEUCHI");

                    b.HasDiscriminator().HasValue("PHIEUCHI");
                });

            modelBuilder.Entity("PHIEUTHU", b =>
                {
                    b.HasBaseType("THUCHI");

                    b.Property<string>("KhuyenMai");

                    b.Property<string>("MaLuot");

                    b.Property<int>("MaNV");

                    b.Property<string>("MaPT");

                    b.Property<string>("PhiDichVuKhac");

                    b.Property<string>("TienHang");

                    b.Property<string>("TongTien");

                    b.Property<string>("VAT");

                    b.ToTable("PHIEUTHU");

                    b.HasDiscriminator().HasValue("PHIEUTHU");
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

            modelBuilder.Entity("QuanLyNhaHang.Models.BlogPermission", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.BlogBusiness", "BlogBusinesses")
                        .WithMany("BlogPermissions")
                        .HasForeignKey("BlogBusinessesBusinessId");
                });
        }
    }
}
