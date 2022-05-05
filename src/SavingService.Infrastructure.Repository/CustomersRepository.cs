using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;
using SavingService.Infrastructure.Interface;
using SavingService.CrossCutting.Common;
using SavingService.Domain.Entity;

namespace SavingService.Infrastructure.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public readonly string _pathToQuery = "fn_cliente";

        public CustomersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public bool Insert(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customers.Cliente_Id);
                parameters.Add("@_user_access_id", customers.User_Access_Id);
                parameters.Add("@_sucursal_id", customers.Sucursal_Id);
                parameters.Add("@_nombre", customers.Nombre);
                parameters.Add("@_apellidos", customers.Apellidos);
                parameters.Add("@_correo", customers.Correo);
                parameters.Add("@_tel_1", customers.Tel_1);
                parameters.Add("@_c_credito", customers.C_Credito);
                parameters.Add("@_c_ahorro", customers.C_Ahorro);
                parameters.Add("@_fh_registro", customers.Fh_Registro);
                parameters.Add("@_fh_modificacion", customers.Fh_Modificacion);
                parameters.Add("@_fh_autorizacion", customers.Fh_Autorizacion);
                parameters.Add("@_usr_registra_id", customers.Usr_Registra_Id);
                parameters.Add("@_usr_modifica_id", customers.Usr_Modifica_Id);
                parameters.Add("@_usr_autoriza_id", customers.Usr_Autoriza_Id);


                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customers.Cliente_Id);
                parameters.Add("@_user_access_id", customers.User_Access_Id);
                parameters.Add("@_sucursal_id", customers.Sucursal_Id);
                parameters.Add("@_nombre", customers.Nombre);
                parameters.Add("@_apellidos", customers.Apellidos);
                parameters.Add("@_correo", customers.Correo);
                parameters.Add("@_tel_1", customers.Tel_1);
                parameters.Add("@_c_credito", customers.C_Credito);
                parameters.Add("@_c_ahorro", customers.C_Ahorro);
                parameters.Add("@_fh_registro", customers.Fh_Registro);
                parameters.Add("@_fh_modificacion", customers.Fh_Modificacion);
                parameters.Add("@_fh_autorizacion", customers.Fh_Autorizacion);
                parameters.Add("@_usr_registra_id", customers.Usr_Registra_Id);
                parameters.Add("@_usr_modifica_id", customers.Usr_Modifica_Id);
                parameters.Add("@_usr_autoriza_id", customers.Usr_Autoriza_Id);


                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Customers Get(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var customer = connection.QuerySingle<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Customers> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var customers = connection.Query<Customers>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        #endregion


        #region Asynchronous Methods
        public async Task<bool> InsertAsync(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customers.Cliente_Id);
                parameters.Add("@_user_access_id", customers.User_Access_Id);
                parameters.Add("@_sucursal_id", customers.Sucursal_Id);
                parameters.Add("@_nombre", customers.Nombre);
                parameters.Add("@_apellidos", customers.Apellidos);
                parameters.Add("@_correo", customers.Correo);
                parameters.Add("@_tel_1", customers.Tel_1);
                parameters.Add("@_c_credito", customers.C_Credito);
                parameters.Add("@_c_ahorro", customers.C_Ahorro);
                parameters.Add("@_fh_registro", customers.Fh_Registro);
                parameters.Add("@_fh_modificacion", customers.Fh_Modificacion);
                parameters.Add("@_fh_autorizacion", customers.Fh_Autorizacion);
                parameters.Add("@_usr_registra_id", customers.Usr_Registra_Id);
                parameters.Add("@_usr_modifica_id", customers.Usr_Modifica_Id);
                parameters.Add("@_usr_autoriza_id", customers.Usr_Autoriza_Id);


                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customers.Cliente_Id);
                parameters.Add("@_user_access_id", customers.User_Access_Id);
                parameters.Add("@_sucursal_id", customers.Sucursal_Id);
                parameters.Add("@_nombre", customers.Nombre);
                parameters.Add("@_apellidos", customers.Apellidos);
                parameters.Add("@_correo", customers.Correo);
                parameters.Add("@_tel_1", customers.Tel_1);
                parameters.Add("@_c_credito", customers.C_Credito);
                parameters.Add("@_c_ahorro", customers.C_Ahorro);
                parameters.Add("@_fh_registro", customers.Fh_Registro);
                parameters.Add("@_fh_modificacion", customers.Fh_Modificacion);
                parameters.Add("@_fh_autorizacion", customers.Fh_Autorizacion);
                parameters.Add("@_usr_registra_id", customers.Usr_Registra_Id);
                parameters.Add("@_usr_modifica_id", customers.Usr_Modifica_Id);
                parameters.Add("@_usr_autoriza_id", customers.Usr_Autoriza_Id);


                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var customer = await connection.QuerySingleAsync<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var customers = await connection.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        #endregion
    }
}
