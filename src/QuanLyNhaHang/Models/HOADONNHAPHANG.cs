﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class HOADONNHAPHANG
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get;
        set;
    }
    public string SoHD
	{
		get;
		set;
	}

	public string ThoiGianNhap
	{
		get;
		set;
	}

	public int MaNV
	{
		get;
		set;
	}

	public int MaNCC
	{
		get;
		set;
	}

	public string ThanhTien
	{
		get;
		set;
	}

	public string NgayLap
	{
		get;
		set;
	}



	//public virtual PHIEUCHI PHIEUCHI
	//{
	//	get;
	//	set;
	//}

	//public virtual YEUCAUNHAPHANG NHAPHANG
	//{
	//	get;
	//	set;
	//}

	//public virtual PHIEUCHI getPhieuChi()
	//{
	//	throw new System.NotImplementedException();
	//}

	//public virtual YEUCAUNHAPHANG getYeuCauNhapHang()
	//{
	//	throw new System.NotImplementedException();
	//}

}

