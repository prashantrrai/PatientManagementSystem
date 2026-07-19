using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Application.Common.Interfaces;
using PatientManagement.Infrastructure.Configuration;
using PatientManagement.Infrastructure.Persistence.ConnectionFactory;
using PatientManagement.Infrastructure.Persistence.Repositories;

namespace PatientManagement.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection(DatabaseSettings.SectionName));

            services.AddScoped<IDbConnectionFactory, SqlConnectionFactory>();

            // Register Repository
            services.AddScoped<IPatientRepository, PatientRepository>();

            return services;
        }
    }
}
