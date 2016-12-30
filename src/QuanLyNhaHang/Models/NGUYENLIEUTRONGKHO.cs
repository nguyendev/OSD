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
    public class NGUYENLIEUTRONGKHO: HETHONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Display(Name = "Mã nguyên liệu")]
        [Required(ErrorMessage = "Vui lòng nhập mã nguyên liệu")]
        [MaxLength(12, ErrorMessage = "Mã nguyên liệu không được quá 12 kí tự")]
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

        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        [Range(0,int.MaxValue,ErrorMessage ="Số lượng không hợp lệ")]
        public int SoLuong
        {
            get;
            set;
        }

        [Display(Name = "Tình trạng")]
        [Required(ErrorMessage = "Vui lòng nhập tình trạng nguyên liệu")]
        public bool TinhTrang
        {
            get;
            set;
        }
    }

}

