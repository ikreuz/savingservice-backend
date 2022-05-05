using SavingService.Application.DTO;
using SavingService.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Application.Interface
{
    public interface IUsersApplication
    {
        #region Synchronous Methods
        Response<bool> Insert(UsersDto userDataDto);
        Response<bool> Update(UsersDto userDataDto);
        Response<bool> Delete(int userDataId);

        Response<UsersDto> Get(int userDataId);
        Response<IEnumerable<UsersDto>> GetAll();

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(UsersDto userDataDto);
        Task<Response<bool>> UpdateAsync(UsersDto userDataDto);
        Task<Response<bool>> DeleteAsync(int userDataId);

        Task<Response<UsersDto>> GetAsync(int userDataId);
        Task<Response<IEnumerable<UsersDto>>> GetAllAsync();
        #endregion
    }
}
