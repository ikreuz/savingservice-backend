using SavingService.Domain.Entity;
using SavingService.Domain.Interface;
using SavingService.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Core
{
    public class RolesDomain : IRolesDomain
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesDomain(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        #region Synchronous Methods

        public bool Insert(Roles roles)
        {
            return _rolesRepository.Insert(roles);
        }

        public bool Update(Roles roles)
        {
            return _rolesRepository.Update(roles);
        }

        public bool Delete(int rolesId)
        {
            return _rolesRepository.Delete(rolesId);
        }

        public Roles Get(int rolesId)
        {
            return _rolesRepository.Get(rolesId);
        }

        public IEnumerable<Roles> GetAll()
        {
            return _rolesRepository.GetAll();
        }

        #endregion

        #region Asynchronous Methods

        public async Task<bool> InsertAsync(Roles roles)
        {
            return await _rolesRepository.InsertAsync(roles);
        }

        public async Task<bool> UpdateAsync(Roles roles)
        {
            return await _rolesRepository.UpdateAsync(roles);
        }

        public async Task<bool> DeleteAsync(int rolesId)
        {
            return await _rolesRepository.DeleteAsync(rolesId);
        }

        public async Task<Roles> GetAsync(int rolesId)
        {
            return await _rolesRepository.GetAsync(rolesId);
        }

        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await _rolesRepository.GetAllAsync();
        }

        #endregion
    }
}