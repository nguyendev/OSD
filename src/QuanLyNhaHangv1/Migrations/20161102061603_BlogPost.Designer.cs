using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuanLyNhaHangv1.Data;

namespace QuanLyNhaHangv1.Migrations
{
    [DbContext(typeof(QuanLyNhaHangDbContext))]
    [Migration("20161102061603_BlogPost")]
    partial class BlogPost
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuanLyNhaHangv1.Models.BlogAdministrator", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte?>("Allowed");

                    b.Property<string>("Avatar")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<byte?>("IsAdmin");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.HasKey("UserId");

                    b.ToTable("blogAdministrator");
                });

            modelBuilder.Entity("QuanLyNhaHangv1.Models.BlogBusiness", b =>
                {
                    b.Property<string>("BussinessId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("BussinessId");

                    b.ToTable("BlogBusiness");
                });

            modelBuilder.Entity("QuanLyNhaHangv1.Models.BlogCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("OrderNo");

                    b.Property<string>("Status")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int?>("UserId");

                    b.HasKey("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("BlogCategory");
                });

            modelBuilder.Entity("QuanLyNhaHangv1.Models.BlogPermission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BussinessId")
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

                    b.HasIndex("BussinessId");

                    b.ToTable("BlogPermission");
                });

            modelBuilder.Entity("QuanLyNhaHangv1.Models.BlogPost", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brief")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1024);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Picture")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Status")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Tags")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 512);

                    b.Property<int?>("UserId");

                    b.Property<int?>("ViewNo");

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("blogPost");
                });

            modelBuilder.Entity("QuanLyNhaHangv1.Models.GrantPermission", b =>
                {
                    b.Property<int>("PermissionId");

                    b.Property<int>("UserId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("PermissionId", "UserId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserId");

                    b.ToTable("GrantPermission");
                });

            modelBuilder.Entity("QuanLyNhaHangv1.Models.BlogCategory", b =>
                {
                    b.HasOne("QuanLyNhaHangv1.Models.BlogAdministrator", "BlogAdministrator")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("QuanLyNhaHangv1.Models.BlogPermission", b =>
                {
                    b.HasOne("QuanLyNhaHangv1.Models.BlogBusiness", "BlogBusinesses")
                        .WithMany("BlogPermissions")
                        .HasForeignKey("BussinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuanLyNhaHangv1.Models.BlogPost", b =>
                {
                    b.HasOne("QuanLyNhaHangv1.Models.BlogCategory", "BlogCategory")
                        .WithMany("BlogPosts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuanLyNhaHangv1.Models.BlogAdministrator", "BlogAdminstrator")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("QuanLyNhaHangv1.Models.GrantPermission", b =>
                {
                    b.HasOne("QuanLyNhaHangv1.Models.BlogPermission", "BlogPermission")
                        .WithMany("GrantPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuanLyNhaHangv1.Models.BlogAdministrator", "BlogAdministrator")
                        .WithMany("GrantPermission")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
