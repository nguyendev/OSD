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
    public class NHAPHANG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public int HoaDonId
        {
            get;
            set;
        }

        public string MaNL
        {
            get;
            set;
        }

        public string SoLuong
        {
            get;
            set;
        }

        public string DonGia
        {
            get;
            set;
        }

        public string MaNCC
        {
            get;
            set;
        }

        //public virtual HOADONNHAPHANG HOADONNHAPHANG
        //{
        //    get;
        //    set;
        //}
    }

}