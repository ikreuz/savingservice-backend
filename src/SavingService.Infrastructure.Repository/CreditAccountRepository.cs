using Dapper;
using SavingService.CrossCutting.Common;
using SavingService.Domain.Entity;
using SavingService.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SavingService.Infrastructure.Repository
{
    public class CreditAccountRepository : ICreditAccountRepository
    {
        public readonly IConnectionFactory _connectionFactory;

        public CreditAccountRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public CreditAccount Get(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_cuenta_ahorro_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customerId);

                var customer = connection.QuerySingle<CreditAccount>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        #endregion


        #region Asynchronous Methods

        public async Task<CreditAccount> GetAsync(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_cuenta_credito_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customerId);

                var customer = await connection.QuerySingleAsync<CreditAccount>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        #endregion
    }
}