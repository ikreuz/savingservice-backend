using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Interface
{
    public interface  ITransactionCreditDomain
    {
        #region Synchronous Methods
        bool Insert(TransactionCredit transaction);
        bool Update(TransactionCredit transaction);
        bool Delete(int transactionId);

        TransactionCredit Get(int transactionId);
        IEnumerable<TransactionCredit> GetAll();
      
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(TransactionCredit transaction);
        Task<bool> UpdateAsync(TransactionCredit transaction);
        Task<bool> DeleteAsync(int transactionId);

        Task<TransactionCredit> GetAsync(int transactionId);
        Task<IEnumerable<TransactionCredit>> GetAllAsync();
        #endregion
    }
}
