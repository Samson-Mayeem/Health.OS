using AutoMapper;
using Health.OS.APi.Repositories.PatientRepo;
using HealthOS.DataAccess.Helpers;

namespace Health.OS.APi._UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        IMapper GetMapper();
        AppSettings GetAppSettings();
        Task<int> SaveChangesAsync();
    }
}
