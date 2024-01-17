using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Floor No")]
        public int FNo { get; set; }

        [Required]
        [Display(Name = "Room No")]
        public int RNo { get; set; }

        [Required]
        [Display(Name = "Room Type")]
        public string RType { get; set; }

        public bool Availability { get; set; }
    }
}
