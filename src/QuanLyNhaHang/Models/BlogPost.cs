using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System;

namespace QuanLyNhaHang.Models
{
    //[Table("BlogPost")]
    public class BlogPost
    {
        [Key]
        [Display(Name = "Mã số")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [Display(Name = "Tiêu đề")]
        [StringLength(512)]
        [Required(ErrorMessage = "Hãy nhập tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Mô tả ngắn gọn")]
        [StringLength(1024)]
        [Required(ErrorMessage = "Hãy nhập mô tả ngắn gọn")]
        public string Brief { get; set; }

        [Display(Name = "Nội dung bài viết")]
        [Required(ErrorMessage = "Hãy nhập nội dung")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [Display(Name = "Ảnh bài viết")]
        [StringLength(256)]
        public string Picture { get; set; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Thẻ tìm kiếm")]
        [StringLength(128)]
        public string Tags { get; set; }

        [Display(Name = "Mã chủ đề")]
        [ForeignKey("BlogCategory")]
        public int CategoryId { get; set; }

        [Display(Name = "Số lần xem")]
        public int? ViewNo { get; set; }

        [Display(Name = "Trạng thái")]
        [StringLength(32)]
        public string Status { get; set; }

        [Display(Name = "Mã người dùng")]
        public int? UserId { get; set; }

        public virtual BlogCategory BlogCategory { get; set; }

        public virtual AppUser BlogAdminstrator { get; set; }



    }
}