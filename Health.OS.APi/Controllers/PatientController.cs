using Health.OS.APi._UnitOfWork;
using HealthOS.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using HealthOS.Models.Users;

namespace Health.OS.APi.Controllers
{
    //[Authorize]
    [Route("healthos/api/v1/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientCreateDto patientDto)
        {
            // Check if the NameIdentifier claim contains a valid Guid
            // Check if the NameIdentifier claim exists
            var nameIdentifierClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine(nameIdentifierClaim);
            if (string.IsNullOrEmpty(nameIdentifierClaim))
            {
                // Handle the case where the NameIdentifier claim is missing or empty
                return BadRequest("NameIdentifier claim is missing or empty.");
            }
           
            if (!Guid.TryParse(nameIdentifierClaim, out Guid staffId))
            {
                // Handle the case where the StaffId is not a valid Guid
                return BadRequest("Invalid StaffId format in the claims.");
            }

            var patient = _mapper.Map<Patient>(patientDto);
            // Set the StaffId from the parsed value
            patient.StaffId = staffId;

            var addedPatient = await _unitOfWork.Patients.AddPatientAsync(patient);

            return CreatedAtAction(nameof(GetPatient), new { id = addedPatient.Id }, addedPatient);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var patient = await _unitOfWork.Patients.GetPatientAsync(id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _unitOfWork.Patients.GetPatientsAsync();
            return Ok(patients);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] PatientGetDto patientDto)
        {
            var existingPatient = await _unitOfWork.Patients.GetPatientAsync(id);
            if (existingPatient == null)
                return NotFound();

            _mapper.Map(patientDto, existingPatient);

            var updatedPatient = await _unitOfWork.Patients.UpdatePatientAsync(id, existingPatient);
            if (updatedPatient == null)
                return BadRequest("Failed to update patient.");

            return Ok(updatedPatient);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var result = await _unitOfWork.Patients.DeletePatientAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
