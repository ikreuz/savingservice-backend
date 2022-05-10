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
    public class CreditAccountApplication : ICreditAccountApplication
    {
        private readonly ICreditAccountDomain _creditAccountDomain;
        private readonly IMapper _mapper;

        public CreditAccountApplication(ICreditAccountDomain creditAccountDomain, IMapper mapper)
        {
            _creditAccountDomain = creditAccountDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos
        public Response<CreditAccountDto> Get(int userDataId)
        {
            var response = new Response<CreditAccountDto>();
            try
            {
                var transaction = _creditAccountDomain.Get(userDataId);
                response.Data = _mapper.Map<CreditAccountDto>(transaction);
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
        public async Task<Response<CreditAccountDto>> GetAsync(int userDataId)
        {
            var response = new Response<CreditAccountDto>();
            try
            {
                var transaction = await _creditAccountDomain.GetAsync(userDataId);
                response.Data = _mapper.Map<CreditAccountDto>(transaction);
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
