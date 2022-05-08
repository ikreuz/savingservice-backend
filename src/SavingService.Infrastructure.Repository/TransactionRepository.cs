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
    public class TransactionRepository : ITransactionRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public readonly string _pathToQuery = "fn_transaccion";

        public TransactionRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public bool Insert(Transaction transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_folio", transaction.Folio);
                parameters.Add("@_cliente_id", transaction.Cliente_Id);
                parameters.Add("@_sucursal_id", transaction.Sucursal_Id);
                parameters.Add("@_fh_registro", transaction.Fh_Registro);
                parameters.Add("@_fh_modificacion", transaction.Fh_Modficacion);
                parameters.Add("@_usr_registra_id", transaction.Usr_Registra);
                parameters.Add("@_usr_modifica_id", transaction.Usr_Modifica);

                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Transaction transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_folio", transaction.Folio);
                parameters.Add("@_cliente_id", transaction.Cliente_Id);
                parameters.Add("@_sucursal_id", transaction.Sucursal_Id);
                parameters.Add("@_fh_registro", transaction.Fh_Registro);
                parameters.Add("@_fh_modificacion", transaction.Fh_Modficacion);
                parameters.Add("@_usr_registra_id", transaction.Usr_Registra);
                parameters.Add("@_usr_modifica_id", transaction.Usr_Modifica);

                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_transaction_id", customerId);

                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Transaction Get(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_transaction_id", customerId);

                var customer = connection.QuerySingle<Transaction>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Transaction> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var transaction = connection.Query<Transaction>(query, commandType: CommandType.StoredProcedure);
                return transaction;
            }
        }
        #endregion


        #region Asynchronous Methods
        public async Task<bool> InsertAsync(Transaction transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_folio", transaction.Folio);
                parameters.Add("@_cliente_id", transaction.Cliente_Id);
                parameters.Add("@_sucursal_id", transaction.Sucursal_Id);
                parameters.Add("@_fh_registro", transaction.Fh_Registro);
                parameters.Add("@_fh_modificacion", transaction.Fh_Modficacion);
                parameters.Add("@_usr_registra_id", transaction.Usr_Registra);
                parameters.Add("@_usr_modifica_id", transaction.Usr_Modifica);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Transaction transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_folio", transaction.Folio);
                parameters.Add("@_cliente_id", transaction.Cliente_Id);
                parameters.Add("@_sucursal_id", transaction.Sucursal_Id);
                parameters.Add("@_fh_registro", transaction.Fh_Registro);
                parameters.Add("@_fh_modificacion", transaction.Fh_Modficacion);
                parameters.Add("@_usr_registra_id", transaction.Usr_Registra);
                parameters.Add("@_usr_modifica_id", transaction.Usr_Modifica);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_transaction_id", customerId);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Transaction> GetAsync(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_transaction_id", customerId);

                var customer = await connection.QuerySingleAsync<Transaction>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var transaction = await connection.QueryAsync<Transaction>(query, commandType: CommandType.StoredProcedure);
                return transaction;
            }
        }
        #endregion
    }
}
