using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Infrastructure.Interface
{
    public interface ITransactionSavingRepository
    {
        #region Synchronous Methods
        bool Insert(TransactionSaving transaction);
        bool Update(TransactionSaving transaction);
        bool Delete(int transactionId);

        TransactionSaving Get(int transactionId);
        IEnumerable<TransactionSaving> GetAll();
        IEnumerable<TransactionSavingCmp> GetAllCmp();
        int GetLast();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(TransactionSaving transaction);
        Task<bool> UpdateAsync(TransactionSaving transaction);
        Task<bool> DeleteAsync(int transactionId);

        Task<TransactionSaving> GetAsync(int transactionId);
        Task<IEnumerable<TransactionSaving>> GetAllAsync();
        #endregion
    }
}
