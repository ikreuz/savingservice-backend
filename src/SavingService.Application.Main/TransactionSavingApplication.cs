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
  public class TransactionSavingApplication : ITransactionSavingApplication
    {
        private readonly ITransactionSavingDomain _transactionSavingDomain;
        private readonly IMapper _mapper;

        public TransactionSavingApplication(ITransactionSavingDomain transactionSavingDomain, IMapper mapper)
        {
            _transactionSavingDomain = transactionSavingDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(TransactionSavingDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<TransactionSaving>(transactionDto);
                response.Data = _transactionSavingDomain.Insert(transaction);
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

        public Response<bool> Update(TransactionSavingDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<TransactionSaving>(transactionDto);
                response.Data = _transactionSavingDomain.Update(transaction);
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
                response.Data = _transactionSavingDomain.Delete(userDataId);
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

        public Response<TransactionSavingDto> Get(int userDataId)
        {
            var response = new Response<TransactionSavingDto>();
            try
            {
                var transaction = _transactionSavingDomain.Get(userDataId);
                response.Data = _mapper.Map<TransactionSavingDto>(transaction);
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

        public Response<IEnumerable<TransactionSavingDto>> GetAll()
        {
            var response = new Response<IEnumerable<TransactionSavingDto>>();
            try
            {
                var transaction = _transactionSavingDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<TransactionSavingDto>>(transaction);
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
        public async Task<Response<bool>> InsertAsync(TransactionSavingDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<TransactionSaving>(transactionDto);
                response.Data = await _transactionSavingDomain.InsertAsync(transaction);
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
        public async Task<Response<bool>> UpdateAsync(TransactionSavingDto transactionDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<TransactionSaving>(transactionDto);
                response.Data = await _transactionSavingDomain.UpdateAsync(transaction);
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
                response.Data = await _transactionSavingDomain.DeleteAsync(userDataId);
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

        public async Task<Response<TransactionSavingDto>> GetAsync(int userDataId)
        {
            var response = new Response<TransactionSavingDto>();
            try
            {
                var transaction = await _transactionSavingDomain.GetAsync(userDataId);
                response.Data = _mapper.Map<TransactionSavingDto>(transaction);
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
        public async Task<Response<IEnumerable<TransactionSavingDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<TransactionSavingDto>>();
            try
            {
                var transaction = await _transactionSavingDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<TransactionSavingDto>>(transaction);
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
