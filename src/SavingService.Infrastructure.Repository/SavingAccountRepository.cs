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

    public class SavingAccountRepository : ISavingAccountRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public readonly string _pathToQuery = "fn_transaccion";

        public SavingAccountRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public IEnumerable<SavingAccount> Get(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_cuenta_ahorro_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customerId);

                var customer = connection.Query<SavingAccount>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        #endregion


        #region Asynchronous Methods

        public async Task<IEnumerable<SavingAccount>> GetAsync(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_cuenta_ahorro_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customerId);

                var customer = await connection.QueryAsync<SavingAccount>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        #endregion
    }
}
