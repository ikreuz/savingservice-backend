using SavingService.Application.DTO;
using SavingService.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Application.Interface
{
    public interface ITransactionSavingApplication
    {
        #region Synchronous Methods
        Response<bool> Insert(TransactionSavingDto transactionDto);
        Response<bool> Update(TransactionSavingDto transactionDto);
        Response<bool> Delete(int transactionId);

        Response<TransactionSavingDto> Get(int transactionId);
        Response<IEnumerable<TransactionSavingDto>> GetAll();
        Response<IEnumerable<TransactionSavingCmpDto>> GetAllCmp();
        Response<int> GetLast();

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(TransactionSavingDto transactionDto);
        Task<Response<bool>> UpdateAsync(TransactionSavingDto transactionDto);
        Task<Response<bool>> DeleteAsync(int transactionId);

        Task<Response<TransactionSavingDto>> GetAsync(int transactionId);
        Task<Response<IEnumerable<TransactionSavingDto>>> GetAllAsync();
        #endregion
    }
}
