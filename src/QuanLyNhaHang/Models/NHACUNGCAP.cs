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
    public class NHACUNGCAP: HETHONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Display(Name = "Mã nhà cung cấp")]
        [Required(ErrorMessage = "Vui lòng nhập mã nhà cung cấp")]
        [MaxLength(12, ErrorMessage = "Mã nhà cung cấp không được quá 12 kí tự")]
        public string MaNCC
        {
            get;
            set;
        }

        [Display(Name = "Tên nhà cung cấp")]
        [Required(ErrorMessage = "Vui lòng nhập tên nhà cung cấp")]
        [MaxLength(50, ErrorMessage = "Tên nhà cung cấp không được quá 50 kí tự")]
        public string TenNCC
        {
            get;
            set;
        }

        [Display(Name ="Địa chỉ")]
        public string DiaChi
        {
            get;
            set;
        }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(15, ErrorMessage = "Số điện thoại không hợp lệ", MinimumLength = 6)]
        public string SoDT
        {
            get;
            set;
        }

        [DataType(DataType.Currency)]
        [Display(Name ="Số nợ")]
        public string SoNo
        {
            get;
            set;
        }

        // public string SoTienNo
        // {
            // get;
            // set;
        // }

        //public virtual YEUCAUNHAPHANG NHAPHANG
        //{
        //	get;
        //	set;
        //}

        //public virtual List<YEUCAUNHAPHANG> getListYeuCau()
        //{
        //	throw new System.NotImplementedException();
        //}

    }

}

