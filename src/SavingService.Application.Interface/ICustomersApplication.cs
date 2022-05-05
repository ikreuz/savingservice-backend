﻿using SavingService.Application.DTO;
using SavingService.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Application.Interface
{
    public interface ICustomersApplication
    {
        #region Synchronous Methods
        Response<bool> Insert(CustomersDto customersDto);
        Response<bool> Update(CustomersDto customersDto);
        Response<bool> Delete(string customerId);

        Response<CustomersDto> Get(string customerId);
        Response<IEnumerable<CustomersDto>> GetAll();

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(CustomersDto customersDto);
        Task<Response<bool>> UpdateAsync(CustomersDto customersDto);
        Task<Response<bool>> DeleteAsync(string customerId);

        Task<Response<CustomersDto>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomersDto>>> GetAllAsync();
        #endregion
    }
}

