using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Infrastructure.Interface
{
    public interface ITowerRepository
    {
        #region Synchronous Methods
        bool Insert(Tower tower);
        bool Update(Tower tower);
        bool Delete(int transactionId);

        Tower Get(int transactionId);
        IEnumerable<Tower> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(Tower tower);
        Task<bool> UpdateAsync(Tower tower);
        Task<bool> DeleteAsync(int transactionId);

        Task<Tower> GetAsync(int transactionId);
        Task<IEnumerable<Tower>> GetAllAsync();
        #endregion
    }
}
