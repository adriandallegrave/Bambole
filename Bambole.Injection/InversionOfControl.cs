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
            services.AddScoped<IProfessorAppService, IProfessorAppService>();
            services.AddScoped<ITurmaAppService, ITurmaAppService>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IProfessorService, IProfessorService>();
            services.AddScoped<ITurmaService, ITurmaService>();
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
