using SavingService.Application.DTO;
using SavingService.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Application.Interface
{
    public interface ITowerApplication
    {
        #region Synchronous Methods
        Response<bool> Insert(TowerDto towerDto);
        Response<bool> Update(TowerDto towerDto);
        Response<bool> Delete(int transactionId);

        Response<TowerDto> Get(int transactionId);
        Response<IEnumerable<TowerDto>> GetAll();

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(TowerDto towerDto);
        Task<Response<bool>> UpdateAsync(TowerDto towerDto);
        Task<Response<bool>> DeleteAsync(int transactionId);

        Task<Response<TowerDto>> GetAsync(int transactionId);
        Task<Response<IEnumerable<TowerDto>>> GetAllAsync();
        #endregion
    }
}
