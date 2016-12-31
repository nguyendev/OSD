using System;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhaHang.Models
{
    public class HETHONG
    {
        [Key]
        private int Id
        {
            get;
            set;
        }
        public DateTime? NgayTao
        {
            get;
            set;
        }
        public DateTime? NgayDuyet
        {
            get;
            set;
        }
        public string TrangThai
        {
            get;
            set;
        }
        public string TrangThaiDuyet
        {
            get;
            set;
        }
        public string GhiChu
        {
            get;
            set;
        }

        public string NguoiTao
        {
            get;
            set;
        }

        public string NguoiDuyet
        {
            get;
            set;
        }
    }
}
