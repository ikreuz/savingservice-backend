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
                parameters.Add("@_numero_cuenta", customers.Numero_Cuenta);
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


                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
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
                parameters.Add("@_numero_cuenta", customers.Numero_Cuenta);
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


                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customerId);

                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Customers Get(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customerId);

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

        public Guid GetGuid(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_conseguir_mid";

                var paremeters = new DynamicParameters();

                paremeters.Add("@_cliente_id", customerId);

                var result = connection.QuerySingle<Guid>(query, param: paremeters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public int GetLast()
        {
            using(var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_ultimo_id";

                var customer = connection.QueryFirstOrDefault<int>(query, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public int GetLastUserAccess()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_ultimo_user_access";

                var customer = connection.QueryFirstOrDefault<int>(query, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public int GetUserAccess(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_conseguir_user_access_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customerId);

                var customer = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.StoredProcedure);
                
                return customer;
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
                parameters.Add("@_numero_cuenta", customers.Numero_Cuenta);
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


                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
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
                parameters.Add("@_numero_cuenta", customers.Numero_Cuenta);
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


                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customerId);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Customers> GetAsync(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_cliente_id", customerId);

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
