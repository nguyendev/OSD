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
    public class NGUYENLIEUTRONGKHO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public int MaNL
        {
            get;
            set;
        }

        public int SoLuong
        {
            get;
            set;
        }

        public bool TinhTrang
        {
            get;
            set;
        }

        //public virtual NGUYENLIEU getNguyenLieu()
        //{
        //	throw new System.NotImplementedException();
        //}

    }

}
