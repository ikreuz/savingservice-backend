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
    public class TowerRepository : ITowerRepository
    {
        public readonly IConnectionFactory _connectionFactory;
        public readonly string _pathToQuery = "fn_tower";

        public TowerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public bool Insert(Tower tower)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_tower_id", tower.Tower_Id);
                parameters.Add("@_role_id", tower.Role_Id);
                parameters.Add("@_usuario_id", tower.Usuario_Id);
                parameters.Add("@_mid", tower.Mid);
                parameters.Add("@_auth", tower.Auth);
                parameters.Add("@_pass", tower.Pass);
                parameters.Add("@_is_staff", tower.Is_Staff);
                parameters.Add("@_fh_registro", tower.Fh_Registro);
                parameters.Add("@_fh_modifcacion", tower.Fh_Modificacion);
                parameters.Add("@_usr_registra_id", tower.Usr_Registra_Id);
                parameters.Add("@_usr_modifica_id", tower.Usr_Modifica_Id);

                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Tower tower)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_tower_id", tower.Tower_Id);
                parameters.Add("@_role_id", tower.Role_Id);
                parameters.Add("@_usuario_id", tower.Usuario_Id);
                parameters.Add("@_mid", tower.Mid);
                parameters.Add("@_auth", tower.Auth);
                parameters.Add("@_pass", tower.Pass);
                parameters.Add("@_is_staff", tower.Is_Staff);
                parameters.Add("@_fh_registro", tower.Fh_Registro);
                parameters.Add("@_fh_modifcacion", tower.Fh_Modificacion);
                parameters.Add("@_usr_registra_id", tower.Usr_Registra_Id);
                parameters.Add("@_usr_modifica_id", tower.Usr_Modifica_Id);

                var result = connection.QueryFirstOrDefault<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(int towerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", towerId);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Tower Get(int towerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", towerId);

                var customer = connection.QueryFirstOrDefault<Tower>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Tower> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var tower = connection.Query<Tower>(query, commandType: CommandType.StoredProcedure);
                return tower;
            }
        }
        #endregion


        #region Asynchronous Methods
        public async Task<bool> InsertAsync(Tower tower)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_insertar";
                var parameters = new DynamicParameters();
                parameters.Add("@_tower_id", tower.Tower_Id);
                parameters.Add("@_role_id", tower.Role_Id);
                parameters.Add("@_usuario_id", tower.Usuario_Id);
                parameters.Add("@_mid", tower.Mid);
                parameters.Add("@_auth", tower.Auth);
                parameters.Add("@_pass", tower.Pass);
                parameters.Add("@_is_staff", tower.Is_Staff);
                parameters.Add("@_fh_registro", tower.Fh_Registro);
                parameters.Add("@_fh_modifcacion", tower.Fh_Modificacion);
                parameters.Add("@_usr_registra_id", tower.Usr_Registra_Id);
                parameters.Add("@_usr_modifica_id", tower.Usr_Modifica_Id);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Tower tower)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_actualizar";
                var parameters = new DynamicParameters();
                parameters.Add("@_tower_id", tower.Tower_Id);
                parameters.Add("@_role_id", tower.Role_Id);
                parameters.Add("@_usuario_id", tower.Usuario_Id);
                parameters.Add("@_mid", tower.Mid);
                parameters.Add("@_auth", tower.Auth);
                parameters.Add("@_pass", tower.Pass);
                parameters.Add("@_is_staff", tower.Is_Staff);
                parameters.Add("@_fh_registro", tower.Fh_Registro);
                parameters.Add("@_fh_modifcacion", tower.Fh_Modificacion);
                parameters.Add("@_usr_registra_id", tower.Usr_Registra_Id);
                parameters.Add("@_usr_modifica_id", tower.Usr_Modifica_Id);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int towerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_eliminar";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", towerId);

                var result = await connection.QueryFirstOrDefaultAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Tower> GetAsync(int towerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_id";
                var parameters = new DynamicParameters();
                parameters.Add("@_credit_id", towerId);

                var customer = await connection.QuerySingleAsync<Tower>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public async Task<IEnumerable<Tower>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = _pathToQuery + "_obtener_listado";

                var tower = await connection.QueryAsync<Tower>(query, commandType: CommandType.StoredProcedure);
                return tower;
            }
        }
        #endregion
    }
}
