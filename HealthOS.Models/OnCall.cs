using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models
{
    public class OnCall
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        [Required]
        public DateTime STime { get; set; }

        [Required]
        public DateTime ETime { get; set; }

        [Required]
        public int StaffId { get; set; }

        [ForeignKey("NurseId")]
        public User Staff { get; set; }
    }
}
