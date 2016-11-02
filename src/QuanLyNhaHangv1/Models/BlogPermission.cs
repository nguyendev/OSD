using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangv1.Models
{
    [Table("BlogPermission")]
    public class BlogPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }

        [Required(ErrorMessage = "Hãy nhập tên quyền hạn")]
        [Display(Name = "Tên quyền")]
        [Column(TypeName = "varchar(256)")]
        [MaxLength(256)]
        public string PermissionName { get; set; }

        [Required(ErrorMessage = "Hãy nhập mô tả quyền hạn")]
        [Display(Name = "Mô tả")]
        [MaxLength(256)]
        public string Description { get; set;}

        [Required]
        [MaxLength(64)]
        [Display(Name = "Mã nghiệp vụ")]
        [Column(TypeName = "varchar(64)")]
        public string BussinessCode { get; set; }
        public virtual BlogBusiness BlogBusinesses { get; set; }

        public virtual ICollection<GrantPermission> GrantPermissions { get; set; }
    }

}
