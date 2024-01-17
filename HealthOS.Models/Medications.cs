using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models
{
    public class Medications
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
