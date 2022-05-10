using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Interface
{
    public interface ISavingAccountDomain
    {
        #region Synchronous Methods
        SavingAccount Get(int accountId);
        #endregion


        #region Asynchronous Methods
        Task<SavingAccount> GetAsync(int accountId);
        #endregion
    }
}
