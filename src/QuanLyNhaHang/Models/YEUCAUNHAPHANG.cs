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
    public class YEUCAUNHAPHANG: HETHONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Required]
        public string MaYeuCau
        {
            get;
            set;
        }

        [Required]
        public string MaNL
        {
            get;
            set;
        }
		
		//kết bảng
		public virtual NGUYENLIEU fNGUYENLIEU
		{
			get;
			set;
		}

        [Required]
        public int SoLuong
        {
            get;
            set;
        }

        [Required]
        public string MaNCC
        {
            get;
            set;
        }

		//kết bảng
		public virtual NHACUNGCAP fNHACUNGCAP
		{
			get;
			set;
		}

        //public virtual HOADONNHAPHANG getHoaDonNhapHang()
        //{
        //	throw new System.NotImplementedException();
        //}

        //public virtual NHACUNGCAP getNhaCungCap()
        //{
        //	throw new System.NotImplementedException();
        //}

        //public virtual NGUYENLIEU getNguyenLieu()
        //{
        //	throw new System.NotImplementedException();
        //}

    }

}

