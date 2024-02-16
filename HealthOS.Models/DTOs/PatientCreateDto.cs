using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models.DTOs
{
    public class PatientCreateDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public string ImageUrl { get; set; }

        public string Mobile { get; set; }

        public string IsuranceCompany { get; set; }

        public string IsuranceNo { get; set; }
    }
}
