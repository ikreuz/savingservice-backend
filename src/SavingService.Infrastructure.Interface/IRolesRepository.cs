using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Infrastructure.Interface
{
    public interface IRolesRepository
    {
        #region Synchronous Methods
        bool Insert(Roles roles);
        bool Update(Roles roles);
        bool Delete(int rolesId);

        Roles Get(int rolesId);
        IEnumerable<Roles> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(Roles roles);
        Task<bool> UpdateAsync(Roles roles);
        Task<bool> DeleteAsync(int rolesId);

        Task<Roles> GetAsync(int rolesId);
        Task<IEnumerable<Roles>> GetAllAsync();
        #endregion
    }
}
