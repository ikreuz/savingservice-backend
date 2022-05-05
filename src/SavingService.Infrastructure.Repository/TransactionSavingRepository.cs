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
  public class TransactionSavingRepository : ITransactionSavingRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public readonly string _pathToQuery = "fn_transaction_saving";

        public TransactionSavingRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public bool Insert(TransactionSaving transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_saving_id", transaction.Saving_ID);
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_documento_id", transaction.Documento_Id);
                parameters.Add("@_cantidad", transaction.Cantidad);
                parameters.Add("@_total", transaction.Total);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(TransactionSaving transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_saving_id", transaction.Saving_ID);
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_documento_id", transaction.Documento_Id);
                parameters.Add("@_cantidad", transaction.Cantidad);
                parameters.Add("@_total", transaction.Total);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(int transactionCreditId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_saving_id", transactionCreditId);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public TransactionSaving Get(int transactionCreditId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_saving_id", transactionCreditId);

                var customer = connection.QuerySingle<TransactionSaving>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<TransactionSaving> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var transaction = connection.Query<TransactionSaving>(query, commandType: CommandType.StoredProcedure);
                return transaction;
            }
        }
        #endregion


        #region Asynchronous Methods
        public async Task<bool> InsertAsync(TransactionSaving transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_saving_id", transaction.Saving_ID);
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_documento_id", transaction.Documento_Id);
                parameters.Add("@_cantidad", transaction.Cantidad);
                parameters.Add("@_total", transaction.Total);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(TransactionSaving transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_saving_id", transaction.Saving_ID);
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_documento_id", transaction.Documento_Id);
                parameters.Add("@_cantidad", transaction.Cantidad);
                parameters.Add("@_total", transaction.Total);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int transactionCreditId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_saving_id", transactionCreditId);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<TransactionSaving> GetAsync(int transactionCreditId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_saving_id", transactionCreditId);

                var customer = await connection.QuerySingleAsync<TransactionSaving>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public async Task<IEnumerable<TransactionSaving>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var transaction = await connection.QueryAsync<TransactionSaving>(query, commandType: CommandType.StoredProcedure);
                return transaction;
            }
        }
        #endregion
    }
}
