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
    public class OnCall
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Room")]
        public Guid RoomId { get; set; }

        public Room Room { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
