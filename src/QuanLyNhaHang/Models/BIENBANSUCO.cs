﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaHang.Models
{
    public class BIENBANSUCO: HETHONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Display(Name = "Mã biên bản")]
        [Required(ErrorMessage = "Vui lòng nhập mã biên bản")]
        [MaxLength(12, ErrorMessage = "Mã biên bản không quá 12 kí tự")]
        public string MaBienBan
        {
            get;
            set;
        }

        [Display(Name = "Mã loại sự cố")]
        //[Required(ErrorMessage = "Vui lòng chọn mã loại sự cố")]
        public string MaLoaiSuCo
        {
            get;
            set;
        }

        //kết bảng
        //public virtual LOAISUCO fLOAISUCO
        //{
        //	get;
        //	set;
        //}

        [Display(Name = "Người lập biên bản")]
       // [Required(ErrorMessage = "Vui lòng chọn mã nhân viên")]
        public string MaNV
        {
            get;
            set;
        }

        //kết bảng
        //public virtual NHANVIEN fNHANVIEN
        //{
        //	get;
        //	set;
        //}
        [Display(Name = "Nguyên nhân")]
        //[Required]
        public string NguyenNhan
        {
            get;
            set;
        }

        [Display(Name = "Thời gian")]
        [Required(ErrorMessage = "Vui lòng nhập thời gian")]
        public string ThoiGian
        {
            get;
            set;
        }

        [Display(Name = "Hướng giải quyết")]
        //[Required]
        public string HuongGiaiQuyet
        {
            get;
            set;
        }

        //public virtual THIETHAI THIETHAI
        //{
        //	get;
        //	set;
        //}

        //public virtual LOAISUCO getLoaiSuCo()
        //{
        //	throw new System.NotImplementedException();
        //}

        //public virtual THIETHAI getThietHai()
        //{
        //	throw new System.NotImplementedException();
        //}

    }

}

