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
    public class THUCHI: HETHONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id
        {
            get;
            set;
        }

        [Display(Name = "Người lập")]
        [Required(ErrorMessage = "Vui lòng nhập mã người lập phiếu")]
        [MaxLength(12, ErrorMessage = "Mã người lập phiếu không quá 12 kí tự")]
        public string NguoiLap	//Ma nhan vien lap
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

        [Required]
        public string ThanhTien
        {
            get;
            set;
        }

        [Display(Name ="Là phiếu thu")]
        public bool LaPhieuThu
        {
            get;
            set;
        }

        //public virtual List<THUCHI> getListThuChi()
        //{
        //	throw new System.NotImplementedException();
        //}

    }

}

