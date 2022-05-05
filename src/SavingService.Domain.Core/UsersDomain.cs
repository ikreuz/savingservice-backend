using SavingService.Domain.Entity;
using SavingService.Domain.Interface;
using SavingService.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _userDataRepository;

        public UsersDomain(IUsersRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
        }

        #region Synchronous Methods

        public bool Insert(Users users)
        {
            return _userDataRepository.Insert(users);
        }

        public bool Update(Users users)
        {
            return _userDataRepository.Update(users);
        }

        public bool Delete(int usresId)
        {
            return _userDataRepository.Delete(usresId);
        }

        public Users Get(int usresId)
        {
            return _userDataRepository.Get(usresId);
        }

        public IEnumerable<Users> GetAll()
        {
            return _userDataRepository.GetAll();
        }

        #endregion

        #region Asynchronous Methods

        public async Task<bool> InsertAsync(Users users)
        {
            return await _userDataRepository.InsertAsync(users);
        }

        public async Task<bool> UpdateAsync(Users users)
        {
            return await _userDataRepository.UpdateAsync(users);
        }

        public async Task<bool> DeleteAsync(int usresId)
        {
            return await _userDataRepository.DeleteAsync(usresId);
        }

        public async Task<Users> GetAsync(int usresId)
        {
            return await _userDataRepository.GetAsync(usresId);
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            return await _userDataRepository.GetAllAsync();
        }

        #endregion
    }
}

