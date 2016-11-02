using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuanLyNhaHangv1.Migrations
{
    public partial class MyFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blogAdministrator",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Allowed = table.Column<byte>(nullable: true),
                    Avatar = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    FullName = table.Column<string>(maxLength: 256, nullable: false),
                    IsAdmin = table.Column<byte>(nullable: true),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    UserName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogAdministrator", x => x.UserId);
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
                name: "BlogCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 256, nullable: false),
                    OrderNo = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 32, nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategory", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_BlogCategory_blogAdministrator_UserId",
                        column: x => x.UserId,
                        principalTable: "blogAdministrator",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "blogPost",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brief = table.Column<string>(maxLength: 1024, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    Picture = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<string>(maxLength: 32, nullable: true),
                    Tags = table.Column<string>(maxLength: 128, nullable: true),
                    Title = table.Column<string>(maxLength: 512, nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ViewNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogPost", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_blogPost_BlogCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BlogCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blogPost_blogAdministrator_UserId",
                        column: x => x.UserId,
                        principalTable: "blogAdministrator",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrantPermission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrantPermission", x => new { x.PermissionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GrantPermission_BlogPermission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "BlogPermission",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrantPermission_blogAdministrator_UserId",
                        column: x => x.UserId,
                        principalTable: "blogAdministrator",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategory_UserId",
                table: "BlogCategory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPermission_BlogBusinessesBusinessId",
                table: "BlogPermission",
                column: "BlogBusinessesBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_blogPost_CategoryId",
                table: "blogPost",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_blogPost_UserId",
                table: "blogPost",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantPermission_PermissionId",
                table: "GrantPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantPermission_UserId",
                table: "GrantPermission",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blogPost");

            migrationBuilder.DropTable(
                name: "GrantPermission");

            migrationBuilder.DropTable(
                name: "BlogCategory");

            migrationBuilder.DropTable(
                name: "BlogPermission");

            migrationBuilder.DropTable(
                name: "blogAdministrator");

            migrationBuilder.DropTable(
                name: "BlogBusiness");
        }
    }
}
