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
        public int FNo { get; set; }

        [Required]
        public int RNo { get; set; }

        [Required]
        public string RType { get; set; }

        public bool Availability { get; set; }
    }
}
