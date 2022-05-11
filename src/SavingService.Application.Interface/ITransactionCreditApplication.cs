using SavingService.Application.DTO;
using SavingService.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Application.Interface
{
    public interface ITransactionCreditApplication
    {
        #region Synchronous Methods
        Response<bool> Insert(TransactionCreditDto transactionDto);
        Response<bool> Update(TransactionCreditDto transactionDto);
        Response<bool> Delete(int transactionId);

        Response<TransactionCreditDto> Get(int transactionId);
        Response<IEnumerable<TransactionCreditDto>> GetAll();
        Response<IEnumerable<TransactionCreditCmpDto>> GetAllCmp();

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(TransactionCreditDto transactionDto);
        Task<Response<bool>> UpdateAsync(TransactionCreditDto transactionDto);
        Task<Response<bool>> DeleteAsync(int transactionId);

        Task<Response<TransactionCreditDto>> GetAsync(int transactionId);
        Task<Response<IEnumerable<TransactionCreditDto>>> GetAllAsync();
        #endregion
    }
}
