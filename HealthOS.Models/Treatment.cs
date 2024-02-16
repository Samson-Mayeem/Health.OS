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
    public class Treatment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [ForeignKey("Procedure")]
        public Guid ProcedureId { get; set; }
        public Procedure Procedure { get; set; }
    }
}
