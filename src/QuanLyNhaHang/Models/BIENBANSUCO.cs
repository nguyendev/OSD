﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BIENBANSUCO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get;
        set;
    }

    public string MaBienBan
	{
		get;
		set;
	}

	public string MaLSC
	{
		get;
		set;
	}

	public string NguyenNhan
	{
		get;
		set;
	}

	public string ThoiGian
	{
		get;
		set;
	}

	public string HuongGiaiQuyet
	{
		get;
		set;
	}

	public string MaNV
	{
		get;
		set;
	}


	//public virtual THIETHAI THIETHAI
	//{
	//	get;
	//	set;
	//}

	//public virtual LOAISUCO getLoaiSuCo()
	//{
	//	throw new System.NotImplementedException();
	//}

	//public virtual THIETHAI getThietHai()
	//{
	//	throw new System.NotImplementedException();
	//}

}

