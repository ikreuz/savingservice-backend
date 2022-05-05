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
  public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _userDataDomain;
        private readonly IMapper _mapper;

        public UsersApplication(IUsersDomain userDataDomain, IMapper mapper)
        {
            _userDataDomain = userDataDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(UsersDto userDataDto)
        {
            var response = new Response<bool>();
            try
            {
                var userData = _mapper.Map<Users>(userDataDto);
                response.Data = _userDataDomain.Insert(userData);
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

        public Response<bool> Update(UsersDto userDataDto)
        {
            var response = new Response<bool>();
            try
            {
                var userData = _mapper.Map<Users>(userDataDto);
                response.Data = _userDataDomain.Update(userData);
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
                response.Data = _userDataDomain.Delete(userDataId);
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

        public Response<UsersDto> Get(int userDataId)
        {
            var response = new Response<UsersDto>();
            try
            {
                var userData = _userDataDomain.Get(userDataId);
                response.Data = _mapper.Map<UsersDto>(userData);
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

        public Response<IEnumerable<UsersDto>> GetAll()
        {
            var response = new Response<IEnumerable<UsersDto>>();
            try
            {
                var userData = _userDataDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<UsersDto>>(userData);
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
        public async Task<Response<bool>> InsertAsync(UsersDto userDataDto)
        {
            var response = new Response<bool>();
            try
            {
                var userData = _mapper.Map<Users>(userDataDto);
                response.Data = await _userDataDomain.InsertAsync(userData);
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
        public async Task<Response<bool>> UpdateAsync(UsersDto userDataDto)
        {
            var response = new Response<bool>();
            try
            {
                var userData = _mapper.Map<Users>(userDataDto);
                response.Data = await _userDataDomain.UpdateAsync(userData);
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
                response.Data = await _userDataDomain.DeleteAsync(userDataId);
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

        public async Task<Response<UsersDto>> GetAsync(int userDataId)
        {
            var response = new Response<UsersDto>();
            try
            {
                var userData = await _userDataDomain.GetAsync(userDataId);
                response.Data = _mapper.Map<UsersDto>(userData);
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
        public async Task<Response<IEnumerable<UsersDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<UsersDto>>();
            try
            {
                var userData = await _userDataDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<UsersDto>>(userData);
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
