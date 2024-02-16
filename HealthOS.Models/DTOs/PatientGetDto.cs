using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models.DTOs
{
    public class PatientGetDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public string Mobile { get; set; }

        public string ICompany { get; set; }

        public string INo { get; set; }
    }
}
