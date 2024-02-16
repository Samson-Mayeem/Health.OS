using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models.Users
{
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public Guid StaffId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string IsuranceCompany { get; set; }

        [Required]
        public string IsuranceNo { get; set; }
    }
}
