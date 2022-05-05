using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Infrastructure.Interface
{
    public interface ICustomersRepository
    {
        #region Synchronous Methods
        bool Insert(Customers customers);
        bool Update(Customers customers);
        bool Delete(string customerId);

        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(Customers customers);
        Task<bool> UpdateAsync(Customers customers);
        Task<bool> DeleteAsync(string customerId);

        Task<Customers> GetAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion
    }
}
