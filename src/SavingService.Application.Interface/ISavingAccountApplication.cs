using SavingService.Application.DTO;
using SavingService.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Application.Interface
{
    public interface ISavingAccountApplication
    {
        #region Synchronous Methods

        Response<IEnumerable<SavingAccountDto>> Get(int accountId);
        #endregion

        #region Métodos Asíncronos
        Task<Response<IEnumerable<SavingAccountDto>>> GetAsync(int accountId);
        #endregion
    }
}
