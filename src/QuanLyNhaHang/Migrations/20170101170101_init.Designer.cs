using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuanLyNhaHang.Data;

namespace QuanLyNhaHang.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170101170101_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ImageUrl");

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

                    b.Property<string>("GhiChu");

                    b.Property<string>("HuongGiaiQuyet")
                        .IsRequired();

                    b.Property<string>("MaBienBan")
                        .IsRequired();

                    b.Property<string>("MaLoaiSuCo")
                        .IsRequired();

                    b.Property<string>("MaNV")
                        .IsRequired();

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("NguyenNhan")
                        .IsRequired();

                    b.Property<string>("ThoiGian")
                        .IsRequired();

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.Property<int?>("fNHANVIENId");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaBienBan");

                    b.HasIndex("fNHANVIENId");

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

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaBP")
                        .IsRequired();

                    b.Property<string>("MaTruongBP");

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("TenBP")
                        .IsRequired();

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaBP");


                    b.HasAlternateKey("TenBP");

                    b.ToTable("BOPHAN");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.CHEBIEN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu");

                    b.Property<float>("LuongDung");

                    b.Property<string>("MaMon")
                        .IsRequired();

                    b.Property<string>("MaNL")
                        .IsRequired();

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.Property<int?>("fMONANId");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaMon", "MaNL");

                    b.HasIndex("fMONANId");

                    b.ToTable("CHEBIEN");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.DATBAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu");

                    b.Property<string>("Gio")
                        .IsRequired();

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Ngay")
                        .IsRequired();

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("SoDT")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("SoNguoi")
                        .IsRequired();

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.ToTable("DATBAN");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.HOADONNHAPHANG", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaHD")
                        .IsRequired();

                    b.Property<string>("MaNCC")
                        .IsRequired();

                    b.Property<string>("MaNV")
                        .IsRequired();

                    b.Property<string>("MaYeuCau")
                        .IsRequired();

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("ThanhTien");

                    b.Property<string>("ThoiGianNhap")
                        .IsRequired();

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaHD");

                    b.ToTable("HOADONNHAHANG");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.LOAIMONAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaLoaiMon")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 12);

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("TenLoaiMon")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaLoaiMon");


                    b.HasAlternateKey("TenLoaiMon");

                    b.ToTable("LOAIMONAN");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.LOAISUCO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaBoPhanXuLy");

                    b.Property<string>("MaLoaiSuCo")
                        .IsRequired();

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("TenLoaiSuCo")
                        .IsRequired();

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaLoaiSuCo");


                    b.HasAlternateKey("TenLoaiSuCo");

                    b.ToTable("LOAISUCO");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.LUOTKHACH", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaLuot")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 12);

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<int>("SoBan");

                    b.Property<string>("ThoiGianRa")
                        .IsRequired();

                    b.Property<string>("ThoiGianVao")
                        .IsRequired();

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaLuot");


                    b.HasAlternateKey("SoBan", "ThoiGianVao");

                    b.ToTable("LUOTKHACH");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.MONAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu");

                    b.Property<string>("Gia")
                        .IsRequired();

                    b.Property<string>("MaLoaiMon")
                        .IsRequired();

                    b.Property<string>("MaMon")
                        .IsRequired();

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("TenMon")
                        .IsRequired();

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaMon");


                    b.HasAlternateKey("TenMon");

                    b.ToTable("MONAN");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NGUYENLIEU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DVT")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("GhiChu");

                    b.Property<string>("Gia")
                        .IsRequired();

                    b.Property<string>("MaNL")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 12);

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("TenNL")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.Property<string>("XuatXu");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaNL");


                    b.HasAlternateKey("TenNL");

                    b.ToTable("NGUYENLIEU");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NGUYENLIEUTRONGKHO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaNL")
                        .IsRequired();

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<int>("SoLuong");

                    b.Property<string>("TinhTrang")
                        .IsRequired();

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaNL");

                    b.ToTable("NGUYENLIEUTRONGKHO");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NHACUNGCAP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiaChi");

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaNCC")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 12);

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("SoDT")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("SoNo");

                    b.Property<string>("TenNCC")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaNCC");


                    b.HasAlternateKey("TenNCC");

                    b.ToTable("NHACUNGCAP");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.NHANVIEN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CMND")
                        .IsRequired();

                    b.Property<string>("DiaChi")
                        .IsRequired();

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaBP")
                        .IsRequired();

                    b.Property<string>("MaNV")
                        .IsRequired();

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<int>("SoDT");

                    b.Property<string>("TenNV")
                        .IsRequired();

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaNV");


                    b.HasAlternateKey("TenNV", "SoDT", "DiaChi", "CMND");

                    b.ToTable("NHANVIEN");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.PHANHOI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu");

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("NoiDung")
                        .IsRequired();

                    b.Property<string>("TenNguoiPH")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.ToTable("PHANHOI");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.THIETHAI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DVT");

                    b.Property<string>("DonGia");

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaBienBan")
                        .IsRequired();

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<int>("SoLuong");

                    b.Property<string>("Ten");

                    b.Property<string>("ThanhTien")
                        .IsRequired();

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.ToTable("THIETHAI");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.THUCHI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("GhiChu");

                    b.Property<bool>("LaPhieuThu");

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiLap");

                    b.Property<string>("NguoiTao");

                    b.Property<string>("ThanhTien")
                        .IsRequired();

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.ToTable("THUCHI");

                    b.HasDiscriminator<string>("Discriminator").HasValue("THUCHI");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.YEUCAUMONAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaLuot")
                        .IsRequired();

                    b.Property<string>("MaMon")
                        .IsRequired();

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<int>("SoLuong");

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.ToTable("YEUCAUMONAN");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.YEUCAUNHAPHANG", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GhiChu");

                    b.Property<string>("MaNCC")
                        .IsRequired();

                    b.Property<string>("MaNL")
                        .IsRequired();

                    b.Property<string>("MaYeuCau")
                        .IsRequired();

                    b.Property<DateTime?>("NgayDuyet");

                    b.Property<DateTime?>("NgayTao");

                    b.Property<string>("NguoiDuyet");

                    b.Property<string>("NguoiTao");

                    b.Property<float>("SoLuong");

                    b.Property<string>("TrangThai");

                    b.Property<string>("TrangThaiDuyet");

                    b.HasKey("Id");

                    b.HasAlternateKey("MaYeuCau");

                    b.ToTable("YEUCAUNHAPHANG");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.PHIEUCHI", b =>
                {
                    b.HasBaseType("QuanLyNhaHang.Models.THUCHI");

                    b.Property<string>("MaHD")
                        .IsRequired();

                    b.Property<string>("MaPC")
                        .IsRequired();

                    b.Property<string>("SoNo");

                    b.ToTable("PHIEUCHI");

                    b.HasDiscriminator().HasValue("PHIEUCHI");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.PHIEUTHU", b =>
                {
                    b.HasBaseType("QuanLyNhaHang.Models.THUCHI");

                    b.Property<string>("KhuyenMai");

                    b.Property<string>("MaLuot")
                        .IsRequired();

                    b.Property<string>("MaPT")
                        .IsRequired();

                    b.Property<string>("PhiDichVuKhac");

                    b.Property<string>("TienHang")
                        .IsRequired();

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

            modelBuilder.Entity("QuanLyNhaHang.Models.BIENBANSUCO", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.NHANVIEN", "fNHANVIEN")
                        .WithMany()
                        .HasForeignKey("fNHANVIENId");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.BlogPermission", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.BlogBusiness", "BlogBusinesses")
                        .WithMany("BlogPermissions")
                        .HasForeignKey("BlogBusinessesBusinessId");
                });

            modelBuilder.Entity("QuanLyNhaHang.Models.CHEBIEN", b =>
                {
                    b.HasOne("QuanLyNhaHang.Models.MONAN", "fMONAN")
                        .WithMany()
                        .HasForeignKey("fMONANId");
                });
        }
    }
}
