using SavingService.Domain.Entity;
using SavingService.Domain.Interface;
using SavingService.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Core
{
    public class TransactionSavingDomain : ITransactionSavingDomain
    {
        private readonly ITransactionSavingRepository _transactionSavingRepository;

        public TransactionSavingDomain(ITransactionSavingRepository transactionSavingRepository)
        {
            _transactionSavingRepository = transactionSavingRepository;
        }

        #region Synchronous Methods

        public bool Insert(TransactionSaving transaction)
        {
            return _transactionSavingRepository.Insert(transaction);
        }

        public bool Update(TransactionSaving transaction)
        {
            return _transactionSavingRepository.Update(transaction);
        }

        public bool Delete(int transactionId)
        {
            return _transactionSavingRepository.Delete(transactionId);
        }

        public TransactionSaving Get(int transactionId)
        {
            return _transactionSavingRepository.Get(transactionId);
        }

        public IEnumerable<TransactionSaving> GetAll()
        {
            return _transactionSavingRepository.GetAll();
        }

        public int GetLast()
        {
            return _transactionSavingRepository.GetLast();
        }
        #endregion

        #region Asynchronous Methods

        public async Task<bool> InsertAsync(TransactionSaving transaction)
        {
            return await _transactionSavingRepository.InsertAsync(transaction);
        }

        public async Task<bool> UpdateAsync(TransactionSaving transaction)
        {
            return await _transactionSavingRepository.UpdateAsync(transaction);
        }

        public async Task<bool> DeleteAsync(int transactionId)
        {
            return await _transactionSavingRepository.DeleteAsync(transactionId);
        }

        public async Task<TransactionSaving> GetAsync(int transactionId)
        {
            return await _transactionSavingRepository.GetAsync(transactionId);
        }

        public async Task<IEnumerable<TransactionSaving>> GetAllAsync()
        {
            return await _transactionSavingRepository.GetAllAsync();
        }

        #endregion
    }
}
