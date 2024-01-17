using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthOS.Models
{
    public class Emails
    {
        [Required(ErrorMessage = "The 'To' field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string To { get; set; } 

        [Required(ErrorMessage = "The 'Subject' field is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "The 'Body' field is required.")]
        public string Body { get; set; }
    }

}
