﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaHang.Models
{
    public class PHIEUTHU : THUCHI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id
        {
            get;
            set;
        }

        [Display(Name = "Mã phiếu thu")]
        [Required(ErrorMessage = "Vui lòng nhập mã phiếu thu")]
        [MaxLength(12, ErrorMessage = "Mã phiếu thu không quá 12 kí tự")]
        public string MaPT
        {
            get;
            set;
        }

        [Display(Name = "Mã lượt khách")]
        [Required(ErrorMessage = "Vui lòng nhập mã lượt khách")]
        [MaxLength(12, ErrorMessage = "Mã lượt khách không quá 12 kí tự")]
        public string MaLuot
        {
            get;
            set;
        }
		
		//kết bảng
		public LUOTKHACH fLUOTKHACH
		{
			get;
			set;
		}

        //kết bảng
        public List<YEUCAUMONAN> fYEUCAUMONAN
        {
            get;
            set;
        }

        [Display(Name ="Tiền hàng")]
        [Required(ErrorMessage ="Vui lòng nhập tiền hàng")]
        public string TienHang
        {
            get;
            set;
        }

        [Display(Name = "Phí dịch vụ khác")]
        public string PhiDichVuKhac
        {
            get;
            set;
        }

        [Display(Name = "Khuyến mãi")]
        public string KhuyenMai
        {
            get;
            set;
        }

        [Display(Name = "Thuế VAT")]
        public string VAT
        {
            get;
            set;
        }

        // public string TongTien
        // {
            // get;
            // set;
        // }

        //public override string NgayLap
        //{
        //	get;
        //	set;
        //}
        //public virtual LUOTKHACH getLuotKhach()
        //{
        //	throw new System.NotImplementedException();
        //}

        //public virtual NHANVIEN getNhanVien()
        //{
        //	throw new System.NotImplementedException();
        //}

    }

}

