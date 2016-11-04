using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangv1.Models
{
    public class BlogAdministrator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Hãy nhập tên người dùng")]
        [StringLength(64, ErrorMessage = "Tên đăng nhập phải từ 3 - 64 ký tự")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [MaxLength(64)]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Hãy nhập họ và tên")]
        [Display(Name = "Họ và tên")]
        [MaxLength(256)]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(256,ErrorMessage = "Email không được vượt quá 256 ký tự")]
        public string Email { get; set; }


        [Display(Name = "Ảnh đại diện")]
        [MaxLength(256, ErrorMessage ="Đường dẫn quá dài, xin vui lòng rút bớt")]
        public string Avatar { get; set; }

        [Display(Name = "Là quản trị")]
        public byte? IsAdmin { get; set; }

        [Display(Name = "Kích hoạt")]
        public byte? Allowed { get; set; }

        //thuộc tính Navigation
        public ICollection<GrantPermission> GrantPermission { get; set; }
    }
}
