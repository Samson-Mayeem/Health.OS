using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HealthOS.Models.Users;

namespace HealthOS.Models
{
    public class Affiliated
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Doctor")]
        public Guid StaffId { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
