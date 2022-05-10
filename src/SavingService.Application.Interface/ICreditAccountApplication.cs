using SavingService.Application.DTO;
using SavingService.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Application.Interface
{
    public interface ICreditAccountApplication
    {
        #region Synchronous Methods
        Response<IEnumerable<CreditAccountDto>> Get(int accountId);
        #endregion

        #region Métodos Asíncronos
        Task<Response<IEnumerable<CreditAccountDto>>> GetAsync(int accountId);
        #endregion
    }
}
