using AutoMapper;
using SavingService.Application.DTO;
using SavingService.Application.Interface;
using SavingService.CrossCutting.Common;
using SavingService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Application.Main
{
    public class SavingAccountApplication : ISavingAccountApplication
    {
        private readonly ISavingAccountDomain _savingAccountDomain;
        private readonly IMapper _mapper;

        public SavingAccountApplication(ISavingAccountDomain savingAccountDomain, IMapper mapper)
        {
            _savingAccountDomain = savingAccountDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos
        public Response<SavingAccountDto> Get(int userDataId)
        {
            var response = new Response<SavingAccountDto>();
            try
            {
                var transaction = _savingAccountDomain.Get(userDataId);
                response.Data = _mapper.Map<SavingAccountDto>(transaction);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        #endregion

        #region Métodos Asíncronos
        public async Task<Response<SavingAccountDto>> GetAsync(int userDataId)
        {
            var response = new Response<SavingAccountDto>();
            try
            {
                var transaction = await _savingAccountDomain.GetAsync(userDataId);
                response.Data = _mapper.Map<SavingAccountDto>(transaction);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        #endregion
    }
}
