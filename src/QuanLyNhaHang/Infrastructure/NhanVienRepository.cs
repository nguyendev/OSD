using Microsoft.EntityFrameworkCore;
using QuanLyNhaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Infrastructure
{
    public class NhanVienRepository : IGenericRepository<NhanVien>
    {
        protected readonly DbContext Context;
        protected DbSet<NhanVien> DbSet;

        public NhanVienRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<NhanVien>();
        }
        public void Add(NhanVien Entity)
        {
            Context.Add(Entity);
            Save();
        }

        public NhanVien Get(int id)
        {
            return DbSet.Where(c => c.Id == id).SingleOrDefault();
        }

        public IQueryable<NhanVien> GetAll()
        {
            return DbSet;
        }

        public void Update(NhanVien Entity)
        {
            Save();
        }

        private void Save()
        {
            Context.SaveChanges();
        }
    }
}
