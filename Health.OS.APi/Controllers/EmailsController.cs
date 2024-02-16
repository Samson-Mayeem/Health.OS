using HealthOS.Models;
using HealthOS.Utility;
using HealthOS.Utility.Emails;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Health.OS.APi.Controllers
{
    [Route("healthos/api/v1/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail([FromBody] Emails emailRequest)
        {
            // Validate the model and send the email
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            try
            {
                var emailSender = new EmailSender("smtp.office365.com", 587, "services@aoholdings.net", "AOHoldings@2022");
                emailSender.SendEmail(emailRequest.To, emailRequest.Subject, emailRequest.Body);
                return Ok("Email sent successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error sending email: {ex.Message}");
            }
        }
    }
}
