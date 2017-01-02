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

        [Display(Name = "Mã người lập phiếu")]
        [Required(ErrorMessage = "Vui lòng chọn mã người lập phiếu")]
        public string NguoiLap	//Ma nhan vien lap
		{
			get;
			set;
		}

        //kết bảng
        //public virtual NHANVIEN fNHANVIEN
        //{
        //	get;
        //	set;
        //}

        //public string NgayLap
        //{
        //    get;
        //    set;
        //}

        [Display(Name = "Thành tiền")]
        [Required]
        [DataType(DataType.Currency)]
        public string ThanhTien
        {
            get;
            set;
        }

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

