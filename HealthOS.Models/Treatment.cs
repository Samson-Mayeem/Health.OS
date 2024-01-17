using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models
{
    public class Treatment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Staff ID")]
        public Guid StaffId { get; set; }

        [ForeignKey("StaffId")]
        public User Staff { get; set; }

        [Display(Name = "Procedure ID")]
        public int? ProcedureId { get; set; }

        [ForeignKey("ProcedureId")]
        public Procedure Procedure { get; set; }
    }
}
