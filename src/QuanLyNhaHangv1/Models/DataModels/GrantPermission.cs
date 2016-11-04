using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaHangv1.Models
{
    [Table("GrantPermission")]
    public class GrantPermission
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("BlogPermission")]
        [Display(Name = "Mã quyền hạn")]
        [Required]
        public int PermissionId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("BlogAdministrator")]
        [Display(Name = "Mã người dùng")]
        [Required]
        public int UserId { get; set; }

        [Display(Name = "Mô tả")]
        [MaxLength(256)]
        public string Description { get; set; }

        //thuộc tính navigation
        public virtual BlogPermission BlogPermission { get; set; }
        public virtual BlogAdministrator BlogAdministrator { get; set; }
    }
}