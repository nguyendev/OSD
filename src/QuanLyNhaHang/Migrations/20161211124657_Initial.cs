using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuanLyNhaHang.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BIENBANSUCO_NHANVIEN_NhanVienId",
                table: "BIENBANSUCO");

            migrationBuilder.DropForeignKey(
                name: "FK_CHEBIEN_MONAN_MonAnId",
                table: "CHEBIEN");

            migrationBuilder.DropForeignKey(
                name: "FK_CHEBIEN_NGUYENLIEU_NguyenLieuId",
                table: "CHEBIEN");

            migrationBuilder.DropForeignKey(
                name: "FK_HOADONNHAHANG_NHACUNGCAP_NhaCungCapId",
                table: "HOADONNHAHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_HOADONNHAHANG_NHANVIEN_NhanVienId",
                table: "HOADONNHAHANG");

            migrationBuilder.DropForeignKey(
                name: "FK_NGUYENLIEUTRONGKHO_NGUYENLIEU_NguyenLieuId",
                table: "NGUYENLIEUTRONGKHO");

            migrationBuilder.DropForeignKey(
                name: "FK_NHANVIEN_BOPHAN_BoPhanId",
                table: "NHANVIEN");

            migrationBuilder.DropForeignKey(
                name: "FK_THIETHAI_BIENBANSUCO_BIENBANSUCOId",
                table: "THIETHAI");

            migrationBuilder.DropForeignKey(
                name: "FK_YEUCAUMONAN_LUOTKHACH_LuotKhachId",
                table: "YEUCAUMONAN");

            migrationBuilder.DropForeignKey(
                name: "FK_YEUCAUMONAN_MONAN_MonAnId",
                table: "YEUCAUMONAN");

            migrationBuilder.DropIndex(
                name: "IX_YEUCAUMONAN_LuotKhachId",
                table: "YEUCAUMONAN");

            migrationBuilder.DropIndex(
                name: "IX_YEUCAUMONAN_MonAnId",
                table: "YEUCAUMONAN");

            migrationBuilder.DropIndex(
                name: "IX_THIETHAI_BIENBANSUCOId",
                table: "THIETHAI");

            migrationBuilder.DropIndex(
                name: "IX_NHANVIEN_BoPhanId",
                table: "NHANVIEN");

            migrationBuilder.DropIndex(
                name: "IX_NGUYENLIEUTRONGKHO_NguyenLieuId",
                table: "NGUYENLIEUTRONGKHO");

            migrationBuilder.DropIndex(
                name: "IX_HOADONNHAHANG_NhaCungCapId",
                table: "HOADONNHAHANG");

            migrationBuilder.DropIndex(
                name: "IX_HOADONNHAHANG_NhanVienId",
                table: "HOADONNHAHANG");

            migrationBuilder.DropIndex(
                name: "IX_CHEBIEN_MonAnId",
                table: "CHEBIEN");

            migrationBuilder.DropIndex(
                name: "IX_CHEBIEN_NguyenLieuId",
                table: "CHEBIEN");

            migrationBuilder.DropIndex(
                name: "IX_BIENBANSUCO_NhanVienId",
                table: "BIENBANSUCO");

            migrationBuilder.DropColumn(
                name: "LuotKhachId",
                table: "YEUCAUMONAN");

            migrationBuilder.DropColumn(
                name: "MonAnId",
                table: "YEUCAUMONAN");

            migrationBuilder.DropColumn(
                name: "BIENBANSUCOId",
                table: "THIETHAI");

            migrationBuilder.DropColumn(
                name: "BienBanId",
                table: "THIETHAI");

            migrationBuilder.DropColumn(
                name: "BoPhanId",
                table: "NHANVIEN");

            migrationBuilder.DropColumn(
                name: "NguyenLieuId",
                table: "NGUYENLIEUTRONGKHO");

            migrationBuilder.DropColumn(
                name: "XuatXu",
                table: "NGUYENLIEU");

            migrationBuilder.DropColumn(
                name: "NhaCungCapId",
                table: "HOADONNHAHANG");

            migrationBuilder.DropColumn(
                name: "NhanVienId",
                table: "HOADONNHAHANG");

            migrationBuilder.DropColumn(
                name: "MonAnId",
                table: "CHEBIEN");

            migrationBuilder.DropColumn(
                name: "NguyenLieuId",
                table: "CHEBIEN");

            migrationBuilder.DropColumn(
                name: "TruongBPId",
                table: "BOPHAN");

            migrationBuilder.DropColumn(
                name: "LoaiSuCo",
                table: "BIENBANSUCO");

            migrationBuilder.DropColumn(
                name: "NguoiChiuTrachNhiem",
                table: "BIENBANSUCO");

            migrationBuilder.DropColumn(
                name: "NhanVienId",
                table: "BIENBANSUCO");

            migrationBuilder.DropTable(
                name: "NHAPHANG");

            migrationBuilder.DropTable(
                name: "PHIEUCHI");

            migrationBuilder.DropTable(
                name: "PHIEUTHU");

            migrationBuilder.DropTable(
                name: "SOTHUCHI");

            migrationBuilder.CreateTable(
                name: "DATBAN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gio = table.Column<string>(nullable: true),
                    HoTen = table.Column<string>(nullable: true),
                    Ngay = table.Column<string>(nullable: true),
                    SoDT = table.Column<string>(nullable: true),
                    SoNguoi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DATBAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LOAISUCO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaBoPhanXuLy = table.Column<int>(nullable: false),
                    MaLSC = table.Column<string>(nullable: true),
                    TenLSC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAISUCO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PHANHOI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoiDung = table.Column<string>(nullable: true),
                    TenNguoiPH = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANHOI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "THUCHI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    LaPhieuThu = table.Column<bool>(nullable: false),
                    NgayLap = table.Column<string>(nullable: true),
                    SoTien = table.Column<string>(nullable: true),
                    MaHoaDon = table.Column<int>(nullable: true),
                    MaPC = table.Column<string>(nullable: true),
                    SoNo = table.Column<string>(nullable: true),
                    SoTienChi = table.Column<string>(nullable: true),
                    KhuyenMai = table.Column<string>(nullable: true),
                    MaLuot = table.Column<string>(nullable: true),
                    MaNV = table.Column<int>(nullable: true),
                    MaPT = table.Column<string>(nullable: true),
                    PhiDichVuKhac = table.Column<string>(nullable: true),
                    TienHang = table.Column<string>(nullable: true),
                    TongTien = table.Column<string>(nullable: true),
                    VAT = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THUCHI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YEUCAUNHAPHANG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DonGia = table.Column<string>(nullable: true),
                    MaNCC = table.Column<int>(nullable: false),
                    MaNL = table.Column<int>(nullable: false),
                    SoHD = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YEUCAUNHAPHANG", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "MaLuot",
                table: "YEUCAUMONAN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaMon",
                table: "YEUCAUMONAN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaBienBan",
                table: "THIETHAI",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaBP",
                table: "NHANVIEN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SoTienNo",
                table: "NHACUNGCAP",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaNL",
                table: "NGUYENLIEUTRONGKHO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaNCC",
                table: "HOADONNHAHANG",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaNV",
                table: "HOADONNHAHANG",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MaMon",
                table: "CHEBIEN",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaNL",
                table: "CHEBIEN",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaTruongBP",
                table: "BOPHAN",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaLSC",
                table: "BIENBANSUCO",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaNV",
                table: "BIENBANSUCO",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaLuot",
                table: "YEUCAUMONAN");

            migrationBuilder.DropColumn(
                name: "MaMon",
                table: "YEUCAUMONAN");

            migrationBuilder.DropColumn(
                name: "MaBienBan",
                table: "THIETHAI");

            migrationBuilder.DropColumn(
                name: "MaBP",
                table: "NHANVIEN");

            migrationBuilder.DropColumn(
                name: "SoTienNo",
                table: "NHACUNGCAP");

            migrationBuilder.DropColumn(
                name: "MaNL",
                table: "NGUYENLIEUTRONGKHO");

            migrationBuilder.DropColumn(
                name: "MaNCC",
                table: "HOADONNHAHANG");

            migrationBuilder.DropColumn(
                name: "MaNV",
                table: "HOADONNHAHANG");

            migrationBuilder.DropColumn(
                name: "MaMon",
                table: "CHEBIEN");

            migrationBuilder.DropColumn(
                name: "MaNL",
                table: "CHEBIEN");

            migrationBuilder.DropColumn(
                name: "MaTruongBP",
                table: "BOPHAN");

            migrationBuilder.DropColumn(
                name: "MaLSC",
                table: "BIENBANSUCO");

            migrationBuilder.DropColumn(
                name: "MaNV",
                table: "BIENBANSUCO");

            migrationBuilder.DropTable(
                name: "DATBAN");

            migrationBuilder.DropTable(
                name: "LOAISUCO");

            migrationBuilder.DropTable(
                name: "PHANHOI");

            migrationBuilder.DropTable(
                name: "THUCHI");

            migrationBuilder.DropTable(
                name: "YEUCAUNHAPHANG");

            migrationBuilder.CreateTable(
                name: "NHAPHANG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DonGia = table.Column<string>(nullable: true),
                    HOADONNHAPHANGId = table.Column<int>(nullable: true),
                    HoaDonId = table.Column<int>(nullable: false),
                    MaNCC = table.Column<string>(nullable: true),
                    MaNL = table.Column<string>(nullable: true),
                    SoLuong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHAPHANG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NHAPHANG_HOADONNHAHANG_HOADONNHAPHANGId",
                        column: x => x.HOADONNHAPHANGId,
                        principalTable: "HOADONNHAHANG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SOTHUCHI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaPC = table.Column<string>(nullable: true),
                    MaPT = table.Column<string>(nullable: true),
                    Ngay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOTHUCHI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUCHI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaNCC = table.Column<string>(nullable: true),
                    MaNV = table.Column<string>(nullable: true),
                    MaPC = table.Column<string>(nullable: true),
                    NgayLap = table.Column<string>(nullable: true),
                    SOTHUCHIId = table.Column<int>(nullable: true),
                    SoHD = table.Column<string>(nullable: true),
                    SoTienChi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIEUCHI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PHIEUCHI_SOTHUCHI_SOTHUCHIId",
                        column: x => x.SOTHUCHIId,
                        principalTable: "SOTHUCHI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHIEUTHU",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KhuyenMai = table.Column<string>(nullable: true),
                    MaLuot = table.Column<string>(nullable: true),
                    MaNV = table.Column<string>(nullable: true),
                    MaPT = table.Column<string>(nullable: true),
                    NgayLap = table.Column<string>(nullable: true),
                    PhiDichVuKhac = table.Column<string>(nullable: true),
                    SOTHUCHIId = table.Column<int>(nullable: true),
                    TienHang = table.Column<string>(nullable: true),
                    TongTien = table.Column<string>(nullable: true),
                    VAT = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHIEUTHU", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PHIEUTHU_SOTHUCHI_SOTHUCHIId",
                        column: x => x.SOTHUCHIId,
                        principalTable: "SOTHUCHI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "LuotKhachId",
                table: "YEUCAUMONAN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonAnId",
                table: "YEUCAUMONAN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BIENBANSUCOId",
                table: "THIETHAI",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BienBanId",
                table: "THIETHAI",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoPhanId",
                table: "NHANVIEN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NguyenLieuId",
                table: "NGUYENLIEUTRONGKHO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "XuatXu",
                table: "NGUYENLIEU",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhaCungCapId",
                table: "HOADONNHAHANG",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NhanVienId",
                table: "HOADONNHAHANG",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonAnId",
                table: "CHEBIEN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NguyenLieuId",
                table: "CHEBIEN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TruongBPId",
                table: "BOPHAN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LoaiSuCo",
                table: "BIENBANSUCO",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiChiuTrachNhiem",
                table: "BIENBANSUCO",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhanVienId",
                table: "BIENBANSUCO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_YEUCAUMONAN_LuotKhachId",
                table: "YEUCAUMONAN",
                column: "LuotKhachId");

            migrationBuilder.CreateIndex(
                name: "IX_YEUCAUMONAN_MonAnId",
                table: "YEUCAUMONAN",
                column: "MonAnId");

            migrationBuilder.CreateIndex(
                name: "IX_THIETHAI_BIENBANSUCOId",
                table: "THIETHAI",
                column: "BIENBANSUCOId");

            migrationBuilder.CreateIndex(
                name: "IX_NHANVIEN_BoPhanId",
                table: "NHANVIEN",
                column: "BoPhanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NGUYENLIEUTRONGKHO_NguyenLieuId",
                table: "NGUYENLIEUTRONGKHO",
                column: "NguyenLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_HOADONNHAHANG_NhaCungCapId",
                table: "HOADONNHAHANG",
                column: "NhaCungCapId");

            migrationBuilder.CreateIndex(
                name: "IX_HOADONNHAHANG_NhanVienId",
                table: "HOADONNHAHANG",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_CHEBIEN_MonAnId",
                table: "CHEBIEN",
                column: "MonAnId");

            migrationBuilder.CreateIndex(
                name: "IX_CHEBIEN_NguyenLieuId",
                table: "CHEBIEN",
                column: "NguyenLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_BIENBANSUCO_NhanVienId",
                table: "BIENBANSUCO",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_NHAPHANG_HOADONNHAPHANGId",
                table: "NHAPHANG",
                column: "HOADONNHAPHANGId");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUCHI_SOTHUCHIId",
                table: "PHIEUCHI",
                column: "SOTHUCHIId");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEUTHU_SOTHUCHIId",
                table: "PHIEUTHU",
                column: "SOTHUCHIId");

            migrationBuilder.AddForeignKey(
                name: "FK_BIENBANSUCO_NHANVIEN_NhanVienId",
                table: "BIENBANSUCO",
                column: "NhanVienId",
                principalTable: "NHANVIEN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CHEBIEN_MONAN_MonAnId",
                table: "CHEBIEN",
                column: "MonAnId",
                principalTable: "MONAN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CHEBIEN_NGUYENLIEU_NguyenLieuId",
                table: "CHEBIEN",
                column: "NguyenLieuId",
                principalTable: "NGUYENLIEU",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HOADONNHAHANG_NHACUNGCAP_NhaCungCapId",
                table: "HOADONNHAHANG",
                column: "NhaCungCapId",
                principalTable: "NHACUNGCAP",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HOADONNHAHANG_NHANVIEN_NhanVienId",
                table: "HOADONNHAHANG",
                column: "NhanVienId",
                principalTable: "NHANVIEN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NGUYENLIEUTRONGKHO_NGUYENLIEU_NguyenLieuId",
                table: "NGUYENLIEUTRONGKHO",
                column: "NguyenLieuId",
                principalTable: "NGUYENLIEU",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NHANVIEN_BOPHAN_BoPhanId",
                table: "NHANVIEN",
                column: "BoPhanId",
                principalTable: "BOPHAN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_THIETHAI_BIENBANSUCO_BIENBANSUCOId",
                table: "THIETHAI",
                column: "BIENBANSUCOId",
                principalTable: "BIENBANSUCO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YEUCAUMONAN_LUOTKHACH_LuotKhachId",
                table: "YEUCAUMONAN",
                column: "LuotKhachId",
                principalTable: "LUOTKHACH",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YEUCAUMONAN_MONAN_MonAnId",
                table: "YEUCAUMONAN",
                column: "MonAnId",
                principalTable: "MONAN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
