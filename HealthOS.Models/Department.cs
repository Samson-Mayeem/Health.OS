using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthOS.Models.Users;

namespace HealthOS.Models
{
    public class Department
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public string StaffId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
