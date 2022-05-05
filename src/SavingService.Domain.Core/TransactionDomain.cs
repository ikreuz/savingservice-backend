using SavingService.Domain.Entity;
using SavingService.Domain.Interface;
using SavingService.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Core
{
    public class TransactionDomain : ITransactionDomain
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionDomain(ITransactionRepository transactionRepository)
        {
            _transactionRepository= transactionRepository;
        }

        #region Synchronous Methods

        public bool Insert(Transaction transaction)
        {
            return _transactionRepository.Insert(transaction);
        }

        public bool Update(Transaction transaction)
        {
            return _transactionRepository.Update(transaction);
        }

        public bool Delete(int transactionId)
        {
            return _transactionRepository.Delete(transactionId);
        }

        public Transaction Get(int transactionId)
        {
            return _transactionRepository.Get(transactionId);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _transactionRepository.GetAll();
        }

        #endregion

        #region Asynchronous Methods

        public async Task<bool> InsertAsync(Transaction transaction)
        {
            return await _transactionRepository.InsertAsync(transaction);
        }

        public async Task<bool> UpdateAsync(Transaction transaction)
        {
            return await _transactionRepository.UpdateAsync(transaction);
        }

        public async Task<bool> DeleteAsync(int transactionId)
        {
            return await _transactionRepository.DeleteAsync(transactionId);
        }

        public async Task<Transaction> GetAsync(int transactionId)
        {
            return await _transactionRepository.GetAsync(transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _transactionRepository.GetAllAsync();
        }

        #endregion
    }
}
