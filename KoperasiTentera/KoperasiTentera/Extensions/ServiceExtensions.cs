using FluentValidation;
using FluentValidation.AspNetCore;
using KoperasiTentera.DataAccess.DTOs;
using KoperasiTentera.DataAccess.Repositories;
using KoperasiTentera.Models;
using KoperasiTentera.Models.Factories;
using KoperasiTentera.Models.Validators;
using KoperasiTentera.Services;

namespace KoperasiTentera.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOtpRequestRepository, OtpRequestRepository>();

            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }

        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerFactory, CustomerFactory>();
            services.AddScoped<IOtpFactory, OtpFactory>();
            services.AddScoped<IUserFactory, UserFactory>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Customer>, CustomerValidator>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOtpRequestService, OtpRequestService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}
