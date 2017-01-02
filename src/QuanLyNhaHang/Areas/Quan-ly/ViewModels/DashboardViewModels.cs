using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyNhaHang.Models;

namespace QuanLyNhaHang.Areas.Quan_ly.ViewModels
{
    public class DashboardViewModels
    {
        public List<DATBAN> _datban { get; set; }
        public List<AppUser> _quantri { get; set; }
        public List<LUOTKHACH> _luotkhach { get; set; }
        public List<MONAN> _monan { get; set; }
        public List<THUCHI> _thuchi { get; set; }

        public int _countManager { get; set; }
        public List<AppUser> _member { get; set; }
        public DashboardViewModels()
        {
            _datban = new List<DATBAN>();
            _quantri = new List<AppUser>();
            _luotkhach = new List<LUOTKHACH>();
            _monan = new List<MONAN>();
            _thuchi = new List<THUCHI>();
        }
    }
}
