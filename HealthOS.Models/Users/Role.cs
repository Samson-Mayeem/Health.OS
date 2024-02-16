using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthOS.Models.ModelInterfaces;

namespace HealthOS.Models.Users
{
    
        public class Role : ICreationAudit, IModificationAudit
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public Guid Id { get; set; }

            [Required]
            public string Name { get; set; }

            public string? Description { get; set; } = string.Empty;

            [Required]
            public bool Active { get; set; }



            [Required]
            public DateTime CreatedDate { get; set; }

            [Required]
            public Guid CreatedBy { get; set; }

            public DateTime? ModifiedDate { get; set; }

            public Guid? ModifiedBy { get; set; }



            //Referenced objects
            public ICollection<UserRole> UserRoles { get; set; }
        }
}
