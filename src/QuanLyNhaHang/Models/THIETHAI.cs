﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace QuanLyNhaHang.Models
{
    public class THIETHAI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }
        public int MaBienBan
        {
            get;
            set;
        }

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
