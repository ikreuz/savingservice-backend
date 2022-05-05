using Microsoft.Extensions.Configuration;
using Npgsql;
using SavingService.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SavingService.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        protected string _connectionString;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public IDbConnection GetConnection
        {
            get
            {
                _connectionString = _configuration.GetSection("ConnectionStrings").GetSection("DBParcelService").Value;

                NpgsqlConnection conn = new NpgsqlConnection(_connectionString);

                conn.Open();

                return conn;
            }
        }
    }
}
