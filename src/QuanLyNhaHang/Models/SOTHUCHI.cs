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
    public class SOTHUCHI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public string Ngay
        {
            get;
            set;
        }

        public string MaPT
        {
            get;
            set;
        }

        public string MaPC
        {
            get;
            set;
        }

    }

}