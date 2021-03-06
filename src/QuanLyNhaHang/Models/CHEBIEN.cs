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
    public class CHEBIEN: HETHONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Display(Name = "Mã món ăn")]
        [Required(ErrorMessage = "Vui lòng chọn mã món ăn")]
        public string MaMon
        {
            get;
            set;
        }

        //kết bảng
        //public MONAN fMONAN
        //{
        //	get;
        //	set;
        //}

        [Display(Name = "Mã nguyên liệu")]
        [Required(ErrorMessage = "Vui lòng chọn mã nguyên liệu")]
        public string MaNL
        {
            get;
            set;
        }

        //kết bảng
        //public NGUYENLIEU fNGUYENLIEU
        //{
        //	get;
        //	set;
        //}

        [Display(Name = "Lượng dùng")]
        [Required(ErrorMessage = "Vui lòng nhập lượng dùng")]
        public float LuongDung
        {
            get;
            set;
        }


        //public virtual NGUYENLIEU getNguyenLieu()
        //{
        //	throw new System.NotImplementedException();
        //}

        //public virtual MONAN getMonAn()
        //{
        //	throw new System.NotImplementedException();
        //}

    }

}

