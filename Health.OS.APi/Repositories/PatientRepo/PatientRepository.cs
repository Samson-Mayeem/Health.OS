using Health.OS.APi.Data;
using HealthOS.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Health.OS.APi.Repositories.PatientRepo
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> GetPatientAsync(Guid id)
        {
            return await _context.Patient.FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _context.Patient.ToListAsync();
        }

        public async Task<bool> DeletePatientAsync(Guid id)
        {
            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
                return false;

            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Patient> UpdatePatientAsync(Guid id, Patient patient)
        {
            var existingPatient = await _context.Patient.FindAsync(id);
            if (existingPatient == null)
                return null;

            existingPatient.FirstName = patient.FirstName;
            existingPatient.LastName = patient.LastName;
            existingPatient.Gender = patient.Gender;
            existingPatient.ImageUrl = patient.ImageUrl;
            existingPatient.Mobile = patient.Mobile;
            existingPatient.IsuranceCompany = patient.IsuranceCompany;
            existingPatient.IsuranceNo = patient.IsuranceNo;

            await _context.SaveChangesAsync();
            return existingPatient;
        }
    }
}
