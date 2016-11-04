using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangv1.Models.DataModels
{
    public class PermissionAction
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public bool IsGranted { get; set; }
    }
}
