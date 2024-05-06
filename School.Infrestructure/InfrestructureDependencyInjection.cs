using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using School.Infrestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using School.Infrestructure.Persistence.Repositories.Base.RepositoryBase;
using School.Infrestructure.Persistence.Repositories.Base.UnitOfWork;

namespace School.Infrestructure
{
    public static class InfrestructureDependencyInjection
    {
        public static IServiceCollection AddInfrestructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddServices(services);
            return services;
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                    .AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        }
      




    }
}
