﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace QuanLyNhaHang.Models
{
    public enum Cities
    {
        None, London, Paris, Chicago
    }
    public enum QualificationLevels
    {
        None, Basic, Advanced
    }

    public class AppUser : IdentityUser
    {
        public string ImageUrl { get; set; }
        public Cities City { get; set; }
        public QualificationLevels Qualifications { get; set; }
        
    }
}
