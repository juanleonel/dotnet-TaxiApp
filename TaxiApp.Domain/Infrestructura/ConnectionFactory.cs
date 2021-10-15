using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TaxiApp.Domain.Infrestructura
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration) {
            _configuration = configuration;
        }
        public IDbConnection GetConnection {
            get {

                var sqlConnection = new SqlConnection();

                if (sqlConnection == null) return null;

                sqlConnection.ConnectionString = _configuration.GetConnectionString("TaxiDB");
                sqlConnection.Open();
                return sqlConnection;

            }
        }
        
    }
}
