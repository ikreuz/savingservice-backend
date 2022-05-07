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
    public class RolesRepository : IRolesRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public readonly string _pathToQuery = "fn_rol";

        public RolesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public bool Insert(Roles roles)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", roles.Role_Id);
                parameters.Add("@_role_name", roles.Role_Name);


                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Roles roles)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", roles.Role_Id);
                parameters.Add("@_role_name", roles.Role_Name);

                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(int rolesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", rolesId);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Roles Get(int rolesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", rolesId);

                var customer = connection.QuerySingle<Roles>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Roles> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var roles = connection.Query<Roles>(query, commandType: CommandType.StoredProcedure);
                return roles;
            }
        }
        #endregion


        #region Asynchronous Methods
        public async Task<bool> InsertAsync(Roles roles)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", roles.Role_Id);
                parameters.Add("@_role_name", roles.Role_Name);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Roles roles)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", roles.Role_Id);
                parameters.Add("@_role_name", roles.Role_Name);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int rolesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", rolesId);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Roles> GetAsync(int rolesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", rolesId);

                var customer = await connection.QuerySingleAsync<Roles>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var roles = await connection.QueryAsync<Roles>(query, commandType: CommandType.StoredProcedure);
                return roles;
            }
        }
        #endregion
    }
}
