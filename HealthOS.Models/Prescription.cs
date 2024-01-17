using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models
{
    public class Prescription
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public ICollection<User> Staff { get; set; }

        [Required]
        public Guid PatientId { get; set; }

        [ForeignKey("PatientId")]
        public ICollection<Patient> Patients { get; set; }

        [Required]
        public Guid MedicationId { get; set; }

        [ForeignKey("MedicationId")]
        public Medications Medication { get; set; }
    }
}
