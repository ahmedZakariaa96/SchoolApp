using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using School.Application.Base.Behaviours;
using School.Application.Handlers.StudentFeature.Services;
using School.Infrestructure.Persistence.Repositories.Base.Mappings;
using System.Reflection;

namespace School.Application
{
    public static class DomainDependencyInjection
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            AddServices(services);
            AddMediator(services);
            AddAutoMapper(services);
            AddHandleException(services);
            AddValidators(services);

            return services;



        }
        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
        }

        private static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
        private static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        }
        private static void AddHandleException(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

        }


    }
}
