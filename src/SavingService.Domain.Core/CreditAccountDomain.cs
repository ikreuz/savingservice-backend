using SavingService.Domain.Entity;
using SavingService.Domain.Interface;
using SavingService.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Core
{
    public class CreditAccountDomain : ICreditAccountDomain
    {
        private readonly ICreditAccountRepository _creditAccountRepository;

        public CreditAccountDomain(ICreditAccountRepository creditAccountRepository)
        {
            _creditAccountRepository = creditAccountRepository;
        }

        #region Synchronous Methods
        public IEnumerable<CreditAccount> Get(int accountId)
        {
            return _creditAccountRepository.Get(accountId);
        }
        #endregion

        #region Asynchronous Methods

        public async Task<IEnumerable<CreditAccount>> GetAsync(int accountId)
        {
            return await _creditAccountRepository.GetAsync(accountId);
        }
        #endregion
    }
}