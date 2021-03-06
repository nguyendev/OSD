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
    public class HOADONNHAPHANG: HETHONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Display(Name = "Mã hóa đơn")]
        [Required(ErrorMessage = "Vui lòng nhập mã hóa đơn")]
        [MaxLength(12, ErrorMessage = "Mã hóa đơn không quá 12 kí tự")]
        public string MaHD
        {
            get;
            set;
        }

        [Display(Name = "Mã yêu cầu")]
        [Required(ErrorMessage = "Vui lòng chọn mã yêu cầu")]
        [MaxLength(12, ErrorMessage = "Mã yêu cầu không quá 12 kí tự")]
        public string MaYeuCau
		{
            get;
            set;
        }
        

        [Display(Name = "Ngày nhập")]
        [Required(ErrorMessage = "Vui lòng nhập ngày nhập")]
        public string ThoiGianNhap
        {
            get;
            set;
        }

        [Display(Name = "Người lập")]
        [Required(ErrorMessage = "Vui lòng nhập người lập")]
        [MaxLength(12, ErrorMessage = "Mã người lập không quá 12 kí tự")]
        public string MaNV
        {
            get;
            set;
        }

        //kết bảng
        //public NHANVIEN fNHANVIEN
        //{
        //	get;
        //	set;
        //}

        [Display(Name = "Mã nhà cung cấp")]
       // [Required(ErrorMessage = "Vui lòng chọn mã nhà cung cấp")]
        public string MaNCC
        {
            get;
            set;
        }

        //kết bảng
        //public NHACUNGCAP fNHACUNGCAP
        //{
        //	get;
        //	set;
        //}
        [Display(Name = "Thành tiền")]
        [DataType(DataType.Currency)]
        public string ThanhTien
        {
            get;
            set;
        }

    }

}

