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
    public class UsersRepository : IUsersRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public readonly string _pathToQuery = "fn_usuario";

        public UsersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public bool Insert(Users userData)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_usuario_id", userData.Usuario_Id);
                parameters.Add("@_nombre", userData.Nombre);
                parameters.Add("@_apellidos", userData.Apellidos);
                parameters.Add("@_correo", userData.Correo);
                parameters.Add("@_nombre_usuario", userData.Nombre_Usuario);
                parameters.Add("@_fh_registro", userData.Fh_Registro);
                parameters.Add("@_fh_modificacion", userData.Fh_Modificacion);
                parameters.Add("@_usr_registra_id", userData.Usr_Registra);
                parameters.Add("@_usr_modifica_id", userData.Usr_Modifica);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Users userData)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_usuario_id", userData.Usuario_Id);
                parameters.Add("@_nombre", userData.Nombre);
                parameters.Add("@_apellidos", userData.Apellidos);
                parameters.Add("@_correo", userData.Correo);
                parameters.Add("@_nombre_usuario", userData.Nombre_Usuario);
                parameters.Add("@_fh_registro", userData.Fh_Registro);
                parameters.Add("@_fh_modificacion", userData.Fh_Modificacion);
                parameters.Add("@_usr_registra_id", userData.Usr_Registra);
                parameters.Add("@_usr_modifica_id", userData.Usr_Modifica);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_usuario_id", customerId);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Users Get(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_usuario_id", customerId);

                var customer = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Users> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var userData = connection.Query<Users>(query, commandType: CommandType.StoredProcedure);
                return userData;
            }
        }
        #endregion


        #region Asynchronous Methods
        public async Task<bool> InsertAsync(Users userData)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_usuario_id", userData.Usuario_Id);
                parameters.Add("@_nombre", userData.Nombre);
                parameters.Add("@_apellidos", userData.Apellidos);
                parameters.Add("@_correo", userData.Correo);
                parameters.Add("@_nombre_usuario", userData.Nombre_Usuario);
                parameters.Add("@_fh_registro", userData.Fh_Registro);
                parameters.Add("@_fh_modificacion", userData.Fh_Modificacion);
                parameters.Add("@_usr_registra_id", userData.Usr_Registra);
                parameters.Add("@_usr_modifica_id", userData.Usr_Modifica);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Users userData)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_usuario_id", userData.Usuario_Id);
                parameters.Add("@_nombre", userData.Nombre);
                parameters.Add("@_apellidos", userData.Apellidos);
                parameters.Add("@_correo", userData.Correo);
                parameters.Add("@_nombre_usuario", userData.Nombre_Usuario);
                parameters.Add("@_fh_registro", userData.Fh_Registro);
                parameters.Add("@_fh_modificacion", userData.Fh_Modificacion);
                parameters.Add("@_usr_registra_id", userData.Usr_Registra);
                parameters.Add("@_usr_modifica_id", userData.Usr_Modifica);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_usuario_id", customerId);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Users> GetAsync(int customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_usuario_id", customerId);

                var customer = await connection.QuerySingleAsync<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var userData = await connection.QueryAsync<Users>(query, commandType: CommandType.StoredProcedure);
                return userData;
            }
        }
        #endregion
    }
}
