using Microsoft.EntityFrameworkCore;
using QuanLyNhaHangv1.Models;

namespace QuanLyNhaHangv1.Data
{
    public class QuanLyNhaHangDbContext : DbContext
    {
        public QuanLyNhaHangDbContext(DbContextOptions<QuanLyNhaHangDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<GrantPermission>()
                .HasKey(c => new { c.PermissionId, c.UserId });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<BlogAdministrator> blogAdministrator { get; set; }

        public DbSet<BlogBusiness> blogBusiness { get; set; }
        public DbSet<BlogPost> blogPost { get; set; }
        public DbSet<BlogPermission> blogPermission { get; set; }
        public DbSet<BlogCategory> blogCategory { get; set; }
        public DbSet<GrantPermission> grantPermission { get; set; }
    }
}
