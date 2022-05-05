using SavingService.Domain.Entity;
using SavingService.Domain.Interface;
using SavingService.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Core
{
    public class TransactionCreditDomain : ITransactionCreditDomain
    {
        private readonly ITransactionCreditRepository _transactionCreditRepository;

        public TransactionCreditDomain(ITransactionCreditRepository transactionCreditRepository)
        {
            _transactionCreditRepository = transactionCreditRepository;
        }

        #region Synchronous Methods

        public bool Insert(TransactionCredit transaction)
        {
            return _transactionCreditRepository.Insert(transaction);
        }

        public bool Update(TransactionCredit transaction)
        {
            return _transactionCreditRepository.Update(transaction);
        }

        public bool Delete(int transactionId)
        {
            return _transactionCreditRepository.Delete(transactionId);
        }

        public TransactionCredit Get(int transactionId)
        {
            return _transactionCreditRepository.Get(transactionId);
        }

        public IEnumerable<TransactionCredit> GetAll()
        {
            return _transactionCreditRepository.GetAll();
        }

        #endregion

        #region Asynchronous Methods

        public async Task<bool> InsertAsync(TransactionCredit transaction)
        {
            return await _transactionCreditRepository.InsertAsync(transaction);
        }

        public async Task<bool> UpdateAsync(TransactionCredit transaction)
        {
            return await _transactionCreditRepository.UpdateAsync(transaction);
        }

        public async Task<bool> DeleteAsync(int transactionId)
        {
            return await _transactionCreditRepository.DeleteAsync(transactionId);
        }

        public async Task<TransactionCredit> GetAsync(int transactionId)
        {
            return await _transactionCreditRepository.GetAsync(transactionId);
        }

        public async Task<IEnumerable<TransactionCredit>> GetAllAsync()
        {
            return await _transactionCreditRepository.GetAllAsync();
        }

        #endregion
    }
}
