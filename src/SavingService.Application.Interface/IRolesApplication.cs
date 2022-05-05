using SavingService.Application.DTO;
using SavingService.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Application.Interface
{
    public interface IRolesApplication
    {
        #region Synchronous Methods
        Response<bool> Insert(RolesDto rolesDto);
        Response<bool> Update(RolesDto rolesDto);
        Response<bool> Delete(int rolesId);

        Response<RolesDto> Get(int rolesId);
        Response<IEnumerable<RolesDto>> GetAll();

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(RolesDto rolesDto);
        Task<Response<bool>> UpdateAsync(RolesDto rolesDto);
        Task<Response<bool>> DeleteAsync(int rolesId);

        Task<Response<RolesDto>> GetAsync(int rolesId);
        Task<Response<IEnumerable<RolesDto>>> GetAllAsync();
        #endregion
    }
}
