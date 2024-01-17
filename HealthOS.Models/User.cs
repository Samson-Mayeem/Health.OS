using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models
{
    public class User : IdentityDbContext
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
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
