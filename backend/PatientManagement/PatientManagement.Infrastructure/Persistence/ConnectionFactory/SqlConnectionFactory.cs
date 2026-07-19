using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using PatientManagement.Infrastructure.Configuration;
using System.Data;

namespace PatientManagement.Infrastructure.Persistence.ConnectionFactory
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly DatabaseSettings _databaseSettings;

        public SqlConnectionFactory(IOptions<DatabaseSettings> options)
        {
            _databaseSettings = options.Value;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_databaseSettings.DefaultConnection);
        }
    }
}
