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
    public class YEUCAUMONAN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public int LuotKhachId
        {
            get;
            set;
        }

        public int MonAnId
        {
            get;
            set;
        }

        public int SoLuong
        {
            get;
            set;
        }

        //public virtual LUOTKHACH LUOTKHACH
        //{
        //    get;
        //    set;
        //}

        //public virtual MONAN MONAN
        //{
        //    get;
        //    set;
        //}
    }
}
