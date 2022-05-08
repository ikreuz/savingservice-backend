using SavingService.Domain.Entity;
using SavingService.Domain.Interface;
using SavingService.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Core
{

        public class TowerDomain : ITowerDomain
        {
            private readonly ITowerRepository _towerRepository;

            public TowerDomain(ITowerRepository towerRepository)
            {
            _towerRepository = towerRepository;
            }

            #region Synchronous Methods

            public bool Insert(Tower tower)
            {
                return _towerRepository.Insert(tower);
            }

            public bool Update(Tower tower)
            {
                return _towerRepository.Update(tower);
            }

            public bool Delete(int transactionId)
            {
                return _towerRepository.Delete(transactionId);
            }

            public Tower Get(int transactionId)
            {
                return _towerRepository.Get(transactionId);
            }

            public IEnumerable<Tower> GetAll()
            {
                return _towerRepository.GetAll();
            }

            #endregion

            #region Asynchronous Methods

            public async Task<bool> InsertAsync(Tower tower)
            {
                return await _towerRepository.InsertAsync(tower);
            }

            public async Task<bool> UpdateAsync(Tower tower)
            {
                return await _towerRepository.UpdateAsync(tower);
            }

            public async Task<bool> DeleteAsync(int transactionId)
            {
                return await _towerRepository.DeleteAsync(transactionId);
            }

            public async Task<Tower> GetAsync(int transactionId)
            {
                return await _towerRepository.GetAsync(transactionId);
            }

            public async Task<IEnumerable<Tower>> GetAllAsync()
            {
                return await _towerRepository.GetAllAsync();
            }

            #endregion
        }
    }
