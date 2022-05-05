using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Infrastructure.Interface
{
    public interface IUsersRepository
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
        Task<bool> DeleteAsync(int userDataId);

        Task<Users> GetAsync(int userDataId);
        Task<IEnumerable<Users>> GetAllAsync();
        #endregion
    }
}
