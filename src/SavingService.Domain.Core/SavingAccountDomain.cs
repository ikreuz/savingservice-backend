using SavingService.Domain.Entity;
using SavingService.Domain.Interface;
using SavingService.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Core
{
    public class SavingAccountDomain : ISavingAccountDomain
    {
        private readonly ISavingAccountRepository _savingAccountRepository;

        public SavingAccountDomain(ISavingAccountRepository savingAccountRepository)
        {
            _savingAccountRepository = savingAccountRepository;
        }

        #region Synchronous Methods
        public IEnumerable<SavingAccount> Get(int accountId)
        {
            return _savingAccountRepository.Get(accountId);
        }
        #endregion

        #region Asynchronous Methods

        public async Task<IEnumerable<SavingAccount>> GetAsync(int accountId)
        {
            return await _savingAccountRepository.GetAsync(accountId);
        }
        #endregion
    }
}
