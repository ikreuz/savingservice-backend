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
 public class TransactionApplication : ITransactionApplication
    {
        private readonly ITransactionDomain _transactionDomain;
        private readonly IMapper _mapper;

        public TransactionApplication(ITransactionDomain transactionDomain, IMapper mapper)
        {
            _transactionDomain = transactionDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(TransactionDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<Transaction>(transactionDto);
                response.Data = _transactionDomain.Insert(transaction);
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

        public Response<bool> Update(TransactionDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<Transaction>(transactionDto);
                response.Data = _transactionDomain.Update(transaction);
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
                response.Data = _transactionDomain.Delete(userDataId);
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

        public Response<TransactionDto> Get(int userDataId)
        {
            var response = new Response<TransactionDto>();
            try
            {
                var transaction = _transactionDomain.Get(userDataId);
                response.Data = _mapper.Map<TransactionDto>(transaction);
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

        public Response<IEnumerable<TransactionDto>> GetAll()
        {
            var response = new Response<IEnumerable<TransactionDto>>();
            try
            {
                var transaction = _transactionDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<TransactionDto>>(transaction);
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
        public async Task<Response<bool>> InsertAsync(TransactionDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<Transaction>(transactionDto);
                response.Data = await _transactionDomain.InsertAsync(transaction);
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
        public async Task<Response<bool>> UpdateAsync(TransactionDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<Transaction>(transactionDto);
                response.Data = await _transactionDomain.UpdateAsync(transaction);
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
                response.Data = await _transactionDomain.DeleteAsync(userDataId);
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

        public async Task<Response<TransactionDto>> GetAsync(int userDataId)
        {
            var response = new Response<TransactionDto>();
            try
            {
                var transaction = await _transactionDomain.GetAsync(userDataId);
                response.Data = _mapper.Map<TransactionDto>(transaction);
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
        public async Task<Response<IEnumerable<TransactionDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<TransactionDto>>();
            try
            {
                var transaction = await _transactionDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<TransactionDto>>(transaction);
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
