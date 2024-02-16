using HealthOS.Models.Users;

namespace Health.OS.APi.Repositories.PatientRepo
{
    public interface IPatientRepository
    {
        Task<Patient> AddPatientAsync(Patient patient);
        Task<Patient> GetPatientAsync(Guid id);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<bool> DeletePatientAsync(Guid id);
        Task<Patient> UpdatePatientAsync(Guid id, Patient patient);
    }
}
