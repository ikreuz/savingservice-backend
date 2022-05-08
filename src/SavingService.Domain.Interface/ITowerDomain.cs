using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Interface
{
    public interface ITowerDomain
    {
        #region Synchronous Methods
        bool Insert(Tower tower);
        bool Update(Tower tower);
        bool Delete(int towerId);

        Tower Get(int towerId);
        IEnumerable<Tower> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(Tower tower);
        Task<bool> UpdateAsync(Tower tower);
        Task<bool> DeleteAsync(int towerId);

        Task<Tower> GetAsync(int towerId);
        Task<IEnumerable<Tower>> GetAllAsync();
        #endregion
    }
}
