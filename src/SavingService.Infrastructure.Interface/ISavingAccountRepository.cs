using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Infrastructure.Interface
{
    public interface ISavingAccountRepository
    {
        #region Synchronous Methods
        IEnumerable<SavingAccount> Get(int accountId);
        #endregion


        #region Asynchronous Methods
        Task<IEnumerable<SavingAccount>> GetAsync(int accountId);
        #endregion
    }
}
