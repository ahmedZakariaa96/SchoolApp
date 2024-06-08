using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Infrestructure.Persistence;
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
            AddIdentityTable(services);
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
        private static void AddIdentityTable(this IServiceCollection services)
        {
            //services.AddIdentity<User, IdentityRole>(option =>
            // {
            //     // Password settings.
            //     option.Password.RequireDigit = true;
            //     option.Password.RequireLowercase = true;
            //     option.Password.RequireNonAlphanumeric = true;
            //     option.Password.RequireUppercase = true;
            //     option.Password.RequiredLength = 6;
            //     option.Password.RequiredUniqueChars = 1;

            //     // Lockout settings.
            //     option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //     option.Lockout.MaxFailedAccessAttempts = 5;
            //     option.Lockout.AllowedForNewUsers = true;

            //     // User settings.
            //     option.User.AllowedUserNameCharacters =
            //     "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //     option.User.RequireUniqueEmail = true;
            //     option.SignIn.RequireConfirmedEmail = true;

            // }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        }




    }
}
