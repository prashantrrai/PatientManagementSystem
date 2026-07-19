using System.Data;

namespace PatientManagement.Infrastructure.Persistence.ConnectionFactory
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
