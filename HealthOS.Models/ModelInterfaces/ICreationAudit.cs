using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models.ModelInterfaces
{
    public interface ICreationAudit
    {
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
