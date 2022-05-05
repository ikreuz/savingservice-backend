using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Interface
{
    public interface IUsersDomain
    {
        #region Synchronous Methods
        bool Insert(Users userData);
        bool Update(Users userData);
        bool Delete(int userDataId);

        Users Get(int userDataId);
        IEnumerable<Users> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(Users userData);
        Task<bool> UpdateAsync(Users userData);
        Task<bool> DeleteAsync(int roleId);

        Task<Users> GetAsync(int roleId);
        Task<IEnumerable<Users>> GetAllAsync();
        #endregion
    }
}
