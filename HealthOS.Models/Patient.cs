using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models
{
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public Guid StaffId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string ICompany { get; set; }

        [Required]
        public string INo { get; set; }
    }
}
