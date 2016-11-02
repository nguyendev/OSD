using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangv1.Models
{
    [Table("BlogBusiness")]
    public class BlogBusiness
    {
        [Key]
        [MaxLength(64)]
        [Display(Name = "Mã nghiệp vụ")]
        public string BussinessId { get; set; }



        [Required(ErrorMessage = "Hãy nhập tên nghiệp vụ")]
        [Display(Name = "Tên nghiệp vụ")]
        [MaxLength(256)]
        public string BusinessName { get; set; }
        public virtual ICollection<BlogPermission> BlogPermissions { get; set; }
    }
}
