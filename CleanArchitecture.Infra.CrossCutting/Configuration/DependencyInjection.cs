using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.Notificacoes;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Account;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Identity;
using CleanArchitecture.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infra.CrossCutting.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(option=> option.AccessDeniedPath = "/Account/Login");
            services.AddScoped<IAuthenticate, AuthenticateRepositori>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();


            services.AddScoped<ApplicationDbContext>();
            // Registro das Dependências das InterfaceRepositório  
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Registro das Dependências dos Serviços 
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();


            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
