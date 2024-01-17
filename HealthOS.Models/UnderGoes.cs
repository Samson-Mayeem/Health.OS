using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models
{
    public class UnderGoes
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Patient ID")]
        public Guid PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patients { get; set; }

        [ForeignKey("StaffId")]
        public User Staff { get; set; }

        [Required]
        [Display(Name = "Nurse ID")]
        public Guid StaffId { get; set; }

        [Display(Name = "Room Usage ID")]
        public Guid? UsageId { get; set; }

        [ForeignKey("UsageId")]
        public Usage Usage { get; set; }

        [Required]
        [Display(Name = "Procedure ID")]
        public Guid ProcedureId { get; set; }

        [ForeignKey("ProcedureId")]
        public Procedure Procedure { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
