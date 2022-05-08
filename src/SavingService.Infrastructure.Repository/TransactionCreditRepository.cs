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
    public class TransactionCreditRepository : ITransactionCreditRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public readonly string _pathToQuery = "fn_transaction_credit";

        public TransactionCreditRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public bool Insert(TransactionCredit transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", transaction.Credit_Id);
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_documento_id", transaction.Documento_Id);
                parameters.Add("@_cobrado", transaction.Cobrado);
                parameters.Add("@_por_cobrar", transaction.Por_Cobrar);
                parameters.Add("@_total", transaction.Total);
                parameters.Add("@_status_id", transaction.Status_Id);

                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(TransactionCredit transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", transaction.Credit_Id);
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_documento_id", transaction.Documento_Id);
                parameters.Add("@_cobrado", transaction.Cobrado);
                parameters.Add("@_por_cobrar", transaction.Por_Cobrar);
                parameters.Add("@_total", transaction.Total);
                parameters.Add("@_status_id", transaction.Status_Id);

                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(int transactionCreditId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", transactionCreditId);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public TransactionCredit Get(int transactionCreditId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", transactionCreditId);

                var customer = connection.QueryFirstOrDefault<TransactionCredit>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<TransactionCredit> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var transaction = connection.Query<TransactionCredit>(query, commandType: CommandType.StoredProcedure);
                return transaction;
            }
        }
        #endregion


        #region Asynchronous Methods
        public async Task<bool> InsertAsync(TransactionCredit transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", transaction.Credit_Id);
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_documento_id", transaction.Documento_Id);
                parameters.Add("@_cobrado", transaction.Cobrado);
                parameters.Add("@_por_cobrar", transaction.Por_Cobrar);
                parameters.Add("@_total", transaction.Total);
                parameters.Add("@_status_id", transaction.Status_Id);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(TransactionCredit transaction)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", transaction.Credit_Id);
                parameters.Add("@_transaction_id", transaction.Transaction_Id);
                parameters.Add("@_documento_id", transaction.Documento_Id);
                parameters.Add("@_cobrado", transaction.Cobrado);
                parameters.Add("@_por_cobrar", transaction.Por_Cobrar);
                parameters.Add("@_total", transaction.Total);
                parameters.Add("@_status_id", transaction.Status_Id);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int transactionCreditId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", transactionCreditId);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<TransactionCredit> GetAsync(int transactionCreditId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", transactionCreditId);

                var customer = await connection.QuerySingleAsync<TransactionCredit>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public async Task<IEnumerable<TransactionCredit>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var transaction = await connection.QueryAsync<TransactionCredit>(query, commandType: CommandType.StoredProcedure);
                return transaction;
            }
        }
        #endregion
    }
}
