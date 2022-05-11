using AutoMapper;
using SavingService.Application.DTO;
using SavingService.Application.Interface;
using SavingService.CrossCutting.Common;
using SavingService.Domain.Entity;
using SavingService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Application.Main
{
    public class TransactionCreditApplication : ITransactionCreditApplication
    {
        private readonly ITransactionCreditDomain _transactionCreditDomain;
        private readonly IMapper _mapper;

        public TransactionCreditApplication(ITransactionCreditDomain transactionCreditDomain, IMapper mapper)
        {
            _transactionCreditDomain = transactionCreditDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(TransactionCreditDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<TransactionCredit>(transactionDto);
                response.Data = _transactionCreditDomain.Insert(transaction);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful registration!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Update(TransactionCreditDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<TransactionCredit>(transactionDto);
                response.Data = _transactionCreditDomain.Update(transaction);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful update!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Delete(int userDataId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _transactionCreditDomain.Delete(userDataId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful removal!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<TransactionCreditDto> Get(int userDataId)
        {
            var response = new Response<TransactionCreditDto>();
            try
            {
                var transaction = _transactionCreditDomain.Get(userDataId);
                response.Data = _mapper.Map<TransactionCreditDto>(transaction);
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

        public Response<IEnumerable<TransactionCreditDto>> GetAll()
        {
            var response = new Response<IEnumerable<TransactionCreditDto>>();
            try
            {
                var transaction = _transactionCreditDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<TransactionCreditDto>>(transaction);
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

        public Response<IEnumerable<TransactionCreditCmpDto>> GetAllCmp()
        {
            var response = new Response<IEnumerable<TransactionCreditCmpDto>>();
            try
            {
                var transaction = _transactionCreditDomain.GetAllCmp();
                response.Data = _mapper.Map<IEnumerable<TransactionCreditCmpDto>>(transaction);
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
        public async Task<Response<bool>> InsertAsync(TransactionCreditDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<TransactionCredit>(transactionDto);
                response.Data = await _transactionCreditDomain.InsertAsync(transaction);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful registration!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(TransactionCreditDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<TransactionCredit>(transactionDto);
                response.Data = await _transactionCreditDomain.UpdateAsync(transaction);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful update!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int userDataId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _transactionCreditDomain.DeleteAsync(userDataId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful removal!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<TransactionCreditDto>> GetAsync(int userDataId)
        {
            var response = new Response<TransactionCreditDto>();
            try
            {
                var transaction = await _transactionCreditDomain.GetAsync(userDataId);
                response.Data = _mapper.Map<TransactionCreditDto>(transaction);
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
        public async Task<Response<IEnumerable<TransactionCreditDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<TransactionCreditDto>>();
            try
            {
                var transaction = await _transactionCreditDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<TransactionCreditDto>>(transaction);
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
