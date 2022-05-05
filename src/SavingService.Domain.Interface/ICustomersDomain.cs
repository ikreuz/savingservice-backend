using SavingService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Domain.Interface
{
    public interface ICustomersDomain
    {
        #region Synchronous Methods
        bool Insert(Customers customers);
        bool Update(Customers customers);
        bool Delete(int customerId);

        Customers Get(int customerId);
        IEnumerable<Customers> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(Customers customers);
        Task<bool> UpdateAsync(Customers customers);
        Task<bool> DeleteAsync(int customerId);

        Task<Customers> GetAsync(int customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion
    }
}
