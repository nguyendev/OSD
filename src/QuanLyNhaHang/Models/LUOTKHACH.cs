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
    public class LUOTKHACH
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }
        public string MaLuot
        {
            get;
            set;
        }

        public int SoBan
        {
            get;
            set;
        }

        public string ThoiGianVao
        {
            get;
            set;
        }

        public string ThoiGianRa
        {
            get;
            set;
        }

   


        //public virtual YEUCAUMONAN YEUCAUMONAN
        //{
        //	get;
        //	set;
        //}

        //public virtual PHIEUTHU PHIEUTHU
        //{
        //	get;
        //	set;
        //}

    }

}
