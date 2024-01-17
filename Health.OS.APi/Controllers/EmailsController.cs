using HealthOS.Models;
using HealthOS.Utility;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Health.OS.APi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        // GET: api/<ValuesController>
       /* [HttpGet]
        public IEnumerable<EmailSender> Get()
        {
            return new EmailSender[0];
        }
*/
        // GET api/<ValuesController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

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


        /*// POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
