using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models
{
    public class Usage
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        [Required]
        public Guid PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Required]
        public DateTime SDate { get; set; }

        [Required]
        public DateTime EDate { get; set; }
    }
}
