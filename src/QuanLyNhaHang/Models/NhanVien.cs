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
    public class NHANVIEN: HETHONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Display(Name = "Mã nhân viên")]
        [Required(ErrorMessage = "Vui lòng nhập mã nhân viên")]
        [MaxLength(12, ErrorMessage = "Mã nhân viên không quá 12 kí tự")]
        public string MaNV
        {
            get;
            set;
        }

        [Display(Name = "Tên nhân viên")]
        [Required(ErrorMessage = "Vui lòng nhập tên nhân viên")]
        [MaxLength(50, ErrorMessage = "Tên nhân viên không quá 50 kí tự")]
        public string TenNV
        {
            get;
            set;
        }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage ="Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage ="Số điện thoại không hợp lệ")]
        [StringLength(15, ErrorMessage ="Số điện thoại không hợp lệ",MinimumLength = 6)]
        public int SoDT
        {
            get;
            set;
        }

        [Display(Name = "Địa chỉ")]
        public string DiaChi
        {
            get;
            set;
        }

        [Display(Name = "Số CMND")]
        [StringLength(10, ErrorMessage = "Số chứng minh nhân dân không hợp lệ", MinimumLength = 9)]
        [Required(ErrorMessage = "Vui lòng nhập số chứng minh nhân dân")]
        public string CMND
        {
            get;
            set;
        }

        [Display(Name = "Mã bộ phận")]
        [Required(ErrorMessage = "Vui lòng nhập mã bộ phận")]
        [MaxLength(12, ErrorMessage = "Mã bộ phận không quá 12 kí tự")]
        public string MaBP
        {
            get;
            set;
        }

		//kết bảng
		public virtual BOPHAN fBOPHAN
		{
			get;
			set;
		}
    }

}

