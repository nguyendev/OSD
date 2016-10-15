using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace QLNH.Models
{
    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }
        public QualificationLevels Qualifications { get; set; }
        public enum Cities
        {
            None, HoChiMinh, HaNoi
        }
        public enum QualificationLevels
        {
            None, Basic, Advanced
        }
    }
}
