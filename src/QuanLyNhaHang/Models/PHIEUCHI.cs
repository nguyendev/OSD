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
    public class PHIEUCHI : THUCHI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id
        {
            get;
            set;
        }

        [Display(Name = "Mã phiếu chi")]
        [Required(ErrorMessage = "Vui lòng nhập mã phiếu chi")]
        [MaxLength(12, ErrorMessage = "Mã phiếu chi không được quá 12 kí tự")]
        public string MaPC
        {
            get;
            set;
        }

        [Display(Name = "Mã hóa đơn")]
        [Required(ErrorMessage = "Vui lòng chọn mã hóa đơn")]
        public string MaHD
        {
            get;
            set;
        }

        //kết bảng
        //public virtual HOADONNHAPHANG fHOADONNHAPHANG
        //{
        //	get;
        //	set;
        //}

        [Display(Name ="Số nợ")]
        [DataType(DataType.Currency)]
        public string SoNo
        {
            get;
            set;
        }

        //public virtual HOADONNHAPHANG getHoaDonNhapHang()
        //{
        //	throw new System.NotImplementedException();
        //}

        //public virtual NHANVIEN getNhanVien()
        //{
        //	throw new System.NotImplementedException();
        //}

    }

}

