using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Repositories;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=ETicaretAPIDb;"),ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository > ();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository > ();
            services.AddSingleton<IOrderReadRepository, OrderReadRepository > ();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository> ();
            services.AddSingleton<IProductReadRepository, ProductReadRepository> ();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository> ();
        }
    }
}
