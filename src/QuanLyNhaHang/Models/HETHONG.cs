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

        [Display(Name ="Ngày tạo")]
        public DateTime? NgayTao
        {
            get;
            set;
        }

        [Display(Name ="Ngày duyệt")]
        public DateTime? NgayDuyet
        {
            get;
            set;
        }

        [Display(Name ="Trạng thái")]
        public string TrangThai
        {
            get;
            set;
        }

        [Display(Name ="Trạng thái duyệt")]
        public string TrangThaiDuyet
        {
            get;
            set;
        }

        [Display(Name ="Ghi chú")]
        [DataType(DataType.MultilineText)]
        public string GhiChu
        {
            get;
            set;
        }
    }
}
