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
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime DTime { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid StaffId { get; set; }

        public User Staff { get; set; }

        [Required]
        public Guid PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
