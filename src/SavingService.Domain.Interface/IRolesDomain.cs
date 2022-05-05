using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Interface
{
    public interface IRolesDomain
    {
        #region Synchronous Methods
        bool Insert(Roles roles);
        bool Update(Roles roles);
        bool Delete(int roleId);

        Roles Get(int roleId);
        IEnumerable<Roles> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(Roles roles);
        Task<bool> UpdateAsync(Roles roles);
        Task<bool> DeleteAsync(int roleId);

        Task<Roles> GetAsync(int roleId);
        Task<IEnumerable<Roles>> GetAllAsync();
        #endregion

    }
}
