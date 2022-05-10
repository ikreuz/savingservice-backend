using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Interface
{
    public interface ICreditAccountDomain
    {
        #region Synchronous Methods
        IEnumerable<CreditAccount> Get(int accountId);
        #endregion


        #region Asynchronous Methods
        Task<IEnumerable<CreditAccount>> GetAsync(int accountId);
        #endregion
    }
}
