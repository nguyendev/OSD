using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuanLyNhaHang.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    City = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    Qualifications = table.Column<int>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BIENBANSUCO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    HuongGiaiQuyet = table.Column<string>(nullable: true),
                    MaBienBan = table.Column<string>(maxLength: 12, nullable: false),
                    MaLoaiSuCo = table.Column<string>(nullable: false),
                    MaNV = table.Column<string>(nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    NguyenNhan = table.Column<string>(nullable: true),
                    ThoiGian = table.Column<string>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIENBANSUCO", x => x.Id);
                    table.UniqueConstraint("AK_BIENBANSUCO_MaBienBan", x => x.MaBienBan);
                });

            migrationBuilder.CreateTable(
                name: "BlogBusiness",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessCode = table.Column<string>(maxLength: 64, nullable: true),
                    BusinessName = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogBusiness", x => x.BusinessId);
                });

            migrationBuilder.CreateTable(
                name: "BOPHAN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    MaBP = table.Column<string>(maxLength: 12, nullable: false),
                    MaTruongBP = table.Column<string>(nullable: true),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    TenBP = table.Column<string>(maxLength: 50, nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOPHAN", x => x.Id);
                    table.UniqueConstraint("AK_BOPHAN_MaBP", x => x.MaBP);
                    table.UniqueConstraint("AK_BOPHAN_TenBP", x => x.TenBP);
                });

            migrationBuilder.CreateTable(
                name: "CHEBIEN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    LuongDung = table.Column<float>(nullable: false),
                    MaMon = table.Column<string>(nullable: false),
                    MaNL = table.Column<string>(nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHEBIEN", x => x.Id);
                    table.UniqueConstraint("AK_CHEBIEN_MaMon_MaNL", x => new { x.MaMon, x.MaNL });
                });

            migrationBuilder.CreateTable(
                name: "DATBAN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    Gio = table.Column<string>(nullable: false),
                    HoTen = table.Column<string>(maxLength: 50, nullable: false),
                    Ngay = table.Column<string>(nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    SoDT = table.Column<string>(maxLength: 15, nullable: false),
                    SoNguoi = table.Column<string>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DATBAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HOADONNHAHANG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    MaHD = table.Column<string>(maxLength: 12, nullable: false),
                    MaNCC = table.Column<string>(nullable: false),
                    MaNV = table.Column<string>(maxLength: 12, nullable: false),
                    MaYeuCau = table.Column<string>(maxLength: 12, nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    ThanhTien = table.Column<string>(nullable: true),
                    ThoiGianNhap = table.Column<string>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADONNHAHANG", x => x.Id);
                    table.UniqueConstraint("AK_HOADONNHAHANG_MaHD", x => x.MaHD);
                });

            migrationBuilder.CreateTable(
                name: "LOAIMONAN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    MaLoaiMon = table.Column<string>(maxLength: 12, nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    TenLoaiMon = table.Column<string>(maxLength: 50, nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAIMONAN", x => x.Id);
                    table.UniqueConstraint("AK_LOAIMONAN_MaLoaiMon", x => x.MaLoaiMon);
                    table.UniqueConstraint("AK_LOAIMONAN_TenLoaiMon", x => x.TenLoaiMon);
                });

            migrationBuilder.CreateTable(
                name: "LOAISUCO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    MaBoPhanXuLy = table.Column<string>(nullable: true),
                    MaLoaiSuCo = table.Column<string>(maxLength: 12, nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    TenLoaiSuCo = table.Column<string>(maxLength: 12, nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAISUCO", x => x.Id);
                    table.UniqueConstraint("AK_LOAISUCO_MaLoaiSuCo", x => x.MaLoaiSuCo);
                    table.UniqueConstraint("AK_LOAISUCO_TenLoaiSuCo", x => x.TenLoaiSuCo);
                });

            migrationBuilder.CreateTable(
                name: "LUOTKHACH",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    MaLuot = table.Column<string>(maxLength: 12, nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    SoBan = table.Column<int>(nullable: false),
                    ThoiGianRa = table.Column<string>(nullable: true),
                    ThoiGianVao = table.Column<string>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LUOTKHACH", x => x.Id);
                    table.UniqueConstraint("AK_LUOTKHACH_MaLuot", x => x.MaLuot);
                    table.UniqueConstraint("AK_LUOTKHACH_SoBan_ThoiGianVao", x => new { x.SoBan, x.ThoiGianVao });
                });

            migrationBuilder.CreateTable(
                name: "MONAN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    Gia = table.Column<string>(nullable: false),
                    MaLoaiMon = table.Column<string>(nullable: false),
                    MaMon = table.Column<string>(maxLength: 12, nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    TenMon = table.Column<string>(maxLength: 50, nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MONAN", x => x.Id);
                    table.UniqueConstraint("AK_MONAN_MaMon", x => x.MaMon);
                    table.UniqueConstraint("AK_MONAN_TenMon", x => x.TenMon);
                });

            migrationBuilder.CreateTable(
                name: "NGUYENLIEU",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DVT = table.Column<string>(maxLength: 20, nullable: false),
                    GhiChu = table.Column<string>(nullable: true),
                    Gia = table.Column<string>(nullable: false),
                    MaNL = table.Column<string>(maxLength: 12, nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    TenNL = table.Column<string>(maxLength: 50, nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true),
                    XuatXu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NGUYENLIEU", x => x.Id);
                    table.UniqueConstraint("AK_NGUYENLIEU_MaNL", x => x.MaNL);
                    table.UniqueConstraint("AK_NGUYENLIEU_TenNL", x => x.TenNL);
                });

            migrationBuilder.CreateTable(
                name: "NGUYENLIEUTRONGKHO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    MaNL = table.Column<string>(nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    SoLuong = table.Column<float>(nullable: false),
                    TinhTrang = table.Column<string>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NGUYENLIEUTRONGKHO", x => x.Id);
                    table.UniqueConstraint("AK_NGUYENLIEUTRONGKHO_MaNL", x => x.MaNL);
                });

            migrationBuilder.CreateTable(
                name: "NHACUNGCAP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaChi = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    MaNCC = table.Column<string>(maxLength: 12, nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    SoDT = table.Column<string>(maxLength: 15, nullable: false),
                    SoNo = table.Column<string>(nullable: true),
                    TenNCC = table.Column<string>(maxLength: 50, nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHACUNGCAP", x => x.Id);
                    table.UniqueConstraint("AK_NHACUNGCAP_MaNCC", x => x.MaNCC);
                    table.UniqueConstraint("AK_NHACUNGCAP_TenNCC", x => x.TenNCC);
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CMND = table.Column<string>(nullable: false),
                    DiaChi = table.Column<string>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true),
                    MaBP = table.Column<string>(nullable: false),
                    MaNV = table.Column<string>(maxLength: 12, nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    SoDT = table.Column<int>(maxLength: 15, nullable: false),
                    TenNV = table.Column<string>(maxLength: 50, nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHANVIEN", x => x.Id);
                    table.UniqueConstraint("AK_NHANVIEN_MaNV", x => x.MaNV);
                    table.UniqueConstraint("AK_NHANVIEN_TenNV_SoDT_DiaChi_CMND", x => new { x.TenNV, x.SoDT, x.DiaChi, x.CMND });
                });

            migrationBuilder.CreateTable(
                name: "PHANHOI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    NoiDung = table.Column<string>(nullable: false),
                    TenNguoiPH = table.Column<string>(maxLength: 50, nullable: true),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANHOI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "THIETHAI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DVT = table.Column<string>(nullable: true),
                    DonGia = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    MaBienBan = table.Column<string>(nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    SoLuong = table.Column<int>(nullable: false),
                    Ten = table.Column<string>(nullable: true),
                    ThanhTien = table.Column<string>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THIETHAI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "THUCHI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true),
                    LaPhieuThu = table.Column<bool>(nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiLap = table.Column<string>(nullable: false),
                    NguoiTao = table.Column<string>(nullable: true),
                    ThanhTien = table.Column<string>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true),
                    MaHD = table.Column<string>(nullable: true),
                    MaPC = table.Column<string>(maxLength: 12, nullable: true),
                    SoNo = table.Column<string>(nullable: true),
                    KhuyenMai = table.Column<string>(nullable: true),
                    MaLuot = table.Column<string>(nullable: true),
                    MaPT = table.Column<string>(maxLength: 12, nullable: true),
                    PhiDichVuKhac = table.Column<string>(nullable: true),
                    TienHang = table.Column<string>(nullable: true),
                    VAT = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THUCHI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YEUCAUMONAN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    MaLuot = table.Column<string>(nullable: false),
                    MaMon = table.Column<string>(nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    SoLuong = table.Column<int>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YEUCAUMONAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YEUCAUNHAPHANG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GhiChu = table.Column<string>(nullable: true),
                    MaNCC = table.Column<string>(nullable: false),
                    MaNL = table.Column<string>(nullable: false),
                    MaYeuCau = table.Column<string>(maxLength: 12, nullable: false),
                    NgayDuyet = table.Column<DateTime>(nullable: true),
                    NgayTao = table.Column<DateTime>(nullable: true),
                    NguoiDuyet = table.Column<string>(nullable: true),
                    NguoiTao = table.Column<string>(nullable: true),
                    SoLuong = table.Column<float>(nullable: false),
                    TrangThai = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YEUCAUNHAPHANG", x => x.Id);
                    table.UniqueConstraint("AK_YEUCAUNHAPHANG_MaYeuCau", x => x.MaYeuCau);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPermission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogBusinessesBusinessId = table.Column<int>(nullable: true),
                    BussinessCode = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: false),
                    PermissionName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPermission", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_BlogPermission_BlogBusiness_BlogBusinessesBusinessId",
                        column: x => x.BlogBusinessesBusinessId,
                        principalTable: "BlogBusiness",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPermission_BlogBusinessesBusinessId",
                table: "BlogPermission",
                column: "BlogBusinessesBusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BIENBANSUCO");

            migrationBuilder.DropTable(
                name: "BlogPermission");

            migrationBuilder.DropTable(
                name: "BOPHAN");

            migrationBuilder.DropTable(
                name: "CHEBIEN");

            migrationBuilder.DropTable(
                name: "DATBAN");

            migrationBuilder.DropTable(
                name: "HOADONNHAHANG");

            migrationBuilder.DropTable(
                name: "LOAIMONAN");

            migrationBuilder.DropTable(
                name: "LOAISUCO");

            migrationBuilder.DropTable(
                name: "LUOTKHACH");

            migrationBuilder.DropTable(
                name: "MONAN");

            migrationBuilder.DropTable(
                name: "NGUYENLIEU");

            migrationBuilder.DropTable(
                name: "NGUYENLIEUTRONGKHO");

            migrationBuilder.DropTable(
                name: "NHACUNGCAP");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "PHANHOI");

            migrationBuilder.DropTable(
                name: "THIETHAI");

            migrationBuilder.DropTable(
                name: "THUCHI");

            migrationBuilder.DropTable(
                name: "YEUCAUMONAN");

            migrationBuilder.DropTable(
                name: "YEUCAUNHAPHANG");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BlogBusiness");
        }
    }
}
