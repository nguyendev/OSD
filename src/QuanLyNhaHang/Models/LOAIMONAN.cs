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

        [Required]
        public string MaLoaiMon
        {
            get;
            set;
        }

        [Required]
        public string TenLoaiMon
        {
            get;
            set;
        }
    }
}
