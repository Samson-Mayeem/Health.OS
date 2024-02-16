using AutoMapper;
using HealthOS.DataAccess.Helpers;
using HealthOS.Models.Users;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstate.Data.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using Health.OS.APi.Data;

namespace Health.OS.APi._UnitOfWork.Repo
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<TEntity> Create<TEntity>(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils, AppSettings appSettings, IMapper mapper) where TEntity : class
        {
            // Check if a specific repository exists for TEntity
            if (typeof(TEntity) == typeof(Company))
            {
                var repository = new CompanyRepository(dbContext, httpContextAccessor) as IRepository<TEntity>;
                if (repository == null) throw new AppException("Invalid repository!");
                return repository;
            }
            //The default repository returned
            return new Repository<TEntity>(dbContext, httpContextAccessor);
        }
    }
}
