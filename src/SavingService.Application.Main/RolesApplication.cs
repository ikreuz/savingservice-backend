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
    public class RolesApplication : IRolesApplication
    {
        private readonly IRolesDomain _rolesDomain;
        private readonly IMapper _mapper;

        public RolesApplication(IRolesDomain rolesDomain, IMapper mapper)
        {
            _rolesDomain = rolesDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(RolesDto rolesDto)
        {
            var response = new Response<bool>();
            try
            {
                var role = _mapper.Map<Roles>(rolesDto);
                response.Data = _rolesDomain.Insert(role);
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

        public Response<bool> Update(RolesDto rolesDto)
        {
            var response = new Response<bool>();
            try
            {
                var role = _mapper.Map<Roles>(rolesDto);
                response.Data = _rolesDomain.Update(role);
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

        public Response<bool> Delete(int roleId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _rolesDomain.Delete(roleId);
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

        public Response<RolesDto> Get(int roleId)
        {
            var response = new Response<RolesDto>();
            try
            {
                var role = _rolesDomain.Get(roleId);
                response.Data = _mapper.Map<RolesDto>(role);
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

        public Response<IEnumerable<RolesDto>> GetAll()
        {
            var response = new Response<IEnumerable<RolesDto>>();
            try
            {
                var roles = _rolesDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<RolesDto>>(roles);
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
        public async Task<Response<bool>> InsertAsync(RolesDto rolesDto)
        {
            var response = new Response<bool>();
            try
            {
                var role = _mapper.Map<Roles>(rolesDto);
                response.Data = await _rolesDomain.InsertAsync(role);
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
        public async Task<Response<bool>> UpdateAsync(RolesDto rolesDto)
        {
            var response = new Response<bool>();
            try
            {
                var role = _mapper.Map<Roles>(rolesDto);
                response.Data = await _rolesDomain.UpdateAsync(role);
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

        public async Task<Response<bool>> DeleteAsync(int roleId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _rolesDomain.DeleteAsync(roleId);
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

        public async Task<Response<RolesDto>> GetAsync(int roleId)
        {
            var response = new Response<RolesDto>();
            try
            {
                var role = await _rolesDomain.GetAsync(roleId);
                response.Data = _mapper.Map<RolesDto>(role);
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
        public async Task<Response<IEnumerable<RolesDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<RolesDto>>();
            try
            {
                var roles = await _rolesDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<RolesDto>>(roles);
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
