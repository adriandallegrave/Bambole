using Bambole.Application.Interfaces;
using Bambole.Application.Services;
using Bambole.Domain.Interfaces;
using Bambole.Domain.Interfaces.Services;
using Bambole.Domain.Services;
using Bambole.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Bambole.Injection
{
    public static class InversionOfControl
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            RegisterApplicationServices(services);
            RegisterDomainServices(services);
            RegisterPersistenceServices(services);
            RegisterToolsServices(services);

            return services;
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IAlunoAppService, AlunoAppService>();
            services.AddScoped<IProfessorAppService, ProfessorAppService>();
            services.AddScoped<ITurmaAppService, TurmaAppService>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<ITurmaService, TurmaService>();
        }

        private static void RegisterPersistenceServices(IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        private static void RegisterToolsServices(IServiceCollection services)
        {
        }
    }
}
