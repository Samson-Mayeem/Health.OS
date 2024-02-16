using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models.Users
{
    public class Doctor
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
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public bool Registered { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Role { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
