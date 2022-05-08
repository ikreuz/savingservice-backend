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
    public class TowerApplication : ITowerApplication
    {
        private readonly ITowerDomain _towerDomain;
        private readonly IMapper _mapper;

        public TowerApplication(ITowerDomain towerDomain, IMapper mapper)
        {
            _towerDomain = towerDomain;
            _mapper = mapper;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(TowerDto towerDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<Tower>(towerDto);
                response.Data = _towerDomain.Insert(transaction);
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

        public Response<bool> Update(TowerDto towerDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<Tower>(towerDto);
                response.Data = _towerDomain.Update(transaction);
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
                response.Data = _towerDomain.Delete(userDataId);
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

        public Response<TowerDto> Get(int userDataId)
        {
            var response = new Response<TowerDto>();
            try
            {
                var transaction = _towerDomain.Get(userDataId);
                response.Data = _mapper.Map<TowerDto>(transaction);
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

        public Response<IEnumerable<TowerDto>> GetAll()
        {
            var response = new Response<IEnumerable<TowerDto>>();
            try
            {
                var transaction = _towerDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<TowerDto>>(transaction);
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
        public async Task<Response<bool>> InsertAsync(TowerDto towerDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<Tower>(towerDto);
                response.Data = await _towerDomain.InsertAsync(transaction);
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
        public async Task<Response<bool>> UpdateAsync(TowerDto towerDto)
        {
            var response = new Response<bool>();
            try
            {
                var transaction = _mapper.Map<Tower>(towerDto);
                response.Data = await _towerDomain.UpdateAsync(transaction);
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
                response.Data = await _towerDomain.DeleteAsync(userDataId);
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

        public async Task<Response<TowerDto>> GetAsync(int userDataId)
        {
            var response = new Response<TowerDto>();
            try
            {
                var transaction = await _towerDomain.GetAsync(userDataId);
                response.Data = _mapper.Map<TowerDto>(transaction);
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
        public async Task<Response<IEnumerable<TowerDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<TowerDto>>();
            try
            {
                var transaction = await _towerDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<TowerDto>>(transaction);
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
