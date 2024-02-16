using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models.Users
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string OtherName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool? ForcePasswordReset { get; set; }

        [StringLength(255)]
        public string? PasswordResetCode { get; set; }

        [StringLength(255)]
        public DateTime? PasswordResetCodeExpiry { get; set; }

        public string? ProfilePicture { get; set; }

        [StringLength(255)]
        public string? ProfileSummary { get; set; }

        [Required]
        public string Gender { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Status { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
