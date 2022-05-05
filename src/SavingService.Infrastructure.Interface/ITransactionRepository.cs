using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Infrastructure.Interface
{
    public interface ITransactionRepository
    {
        #region Synchronous Methods
        bool Insert(Transaction transaction);
        bool Update(Transaction transaction);
        bool Delete(int transactionId);

        Transaction Get(int transactionId);
        IEnumerable<Transaction> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(Transaction transaction);
        Task<bool> UpdateAsync(Transaction transaction);
        Task<bool> DeleteAsync(int transactionId);

        Task<Transaction> GetAsync(int transactionId);
        Task<IEnumerable<Transaction>> GetAllAsync();
        #endregion
    }
}
