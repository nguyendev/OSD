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
    public class BOPHAN: HETHONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Required]
        public string MaBP
        {
            get;
            set;
        }

        [Required]
        public string TenBP
        {
            get;
            set;
        }

        public string MaTruongBP
        {
            get;
            set;
        }

		//kết bảng
		public virtual NHANVIEN fNHANVIEN
		{
			get;
			set;
		}

        //public virtual LOAISUCO LOAISUCO
        //{
        //	get;
        //	set;
        //}

        //public virtual List<NHANVIEN> getListNhanVien()
        //{
        //	throw new System.NotImplementedException();
        //}

        //public virtual List<LOAISUCO> getListLoaiSuCo()
        //{
        //	throw new System.NotImplementedException();
        //}

    }

}

