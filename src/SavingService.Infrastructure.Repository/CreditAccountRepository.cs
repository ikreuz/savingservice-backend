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

        public IEnumerable<CreditAccount> Get(int accountId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_cuenta_ahorro_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", accountId);

                var account = connection.Query<CreditAccount>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return account;
            }
        }
        #endregion


        #region Asynchronous Methods

        public async Task<IEnumerable<CreditAccount>> GetAsync(int accountId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_cuenta_credito_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", accountId);

                var account = await connection.QueryAsync<CreditAccount>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return account;
            }
        }
        #endregion
    }
}