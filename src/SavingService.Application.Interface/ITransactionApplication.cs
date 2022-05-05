using SavingService.Application.DTO;
using SavingService.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Application.Interface
{
    public interface ITransactionApplication
    {
        #region Synchronous Methods
        Response<bool> Insert(TransactionDto transactionDto);
        Response<bool> Update(TransactionDto transactionDto);
        Response<bool> Delete(int transactionId);

        Response<TransactionDto> Get(int transactionId);
        Response<IEnumerable<TransactionDto>> GetAll();

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(TransactionDto transactionDto);
        Task<Response<bool>> UpdateAsync(TransactionDto transactionDto);
        Task<Response<bool>> DeleteAsync(int transactionId);

        Task<Response<TransactionDto>> GetAsync(int transactionId);
        Task<Response<IEnumerable<TransactionDto>>> GetAllAsync();
        #endregion
    }
}
