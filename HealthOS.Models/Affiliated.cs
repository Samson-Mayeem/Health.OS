using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models
{
    public class Affiliated
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public Guid StaffId { get; set; }
        [ForeignKey("UserId")]
        public ICollection<User> Doctors { get; set; }
    }
}
