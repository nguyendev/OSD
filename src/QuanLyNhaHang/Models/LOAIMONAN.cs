using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaHang.Models
{
    public class LOAIMONAN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }
        public string MaLoaiMon
        {
            get;
            set;
        }

        public string TenLoaiMon
        {
            get;
            set;
        }
    }
}
