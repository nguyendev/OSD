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
    public class THIETHAI: HETHONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Required]
        public string MaBienBan
        {
            get;
            set;
        }
		
		//kết bảng
		//public virtual BIENBANSUCO fBIENBANSUCO
		//{
		//	get;
		//	set;
		//}
		
        public string Ten
        {
            get;
            set;
        }

        public int SoLuong
        {
            get;
            set;
        }

        public string DVT
        {
            get;
            set;
        }

        public string DonGia
        {
            get;
            set;
        }

        [Required]
        public string ThanhTien
        {
            get;
            set;
        }



        //public virtual BIENBANSUCO getBienBanSuCo()
        //{
        //	throw new System.NotImplementedException();
        //}

    }

}

