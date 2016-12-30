using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaHang.Models
{
    public class LOAIMONAN: HETHONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Display(Name ="Mã loại món")]
        [Required(ErrorMessage ="Vui lòng nhập mã loại món")]
        [MaxLength(12, ErrorMessage = "Mã loại món không quá 12 kí tự")]
        public string MaLoaiMon
        {
            get;
            set;
        }

        [Display(Name ="Tên loại món")]
        [Required(ErrorMessage ="Vui lòng nhập tên loại món")]
        [MaxLength(50, ErrorMessage = "Tên loại món không quá 50 kí tự")]
        public string TenLoaiMon
        {
            get;
            set;
        }
    }
}
