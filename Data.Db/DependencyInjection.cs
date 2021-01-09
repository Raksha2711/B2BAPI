using System;
using System.Collections.Generic;
using System.Text;
using Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Db
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<B2bDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                //options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;

            //public static void ConfigureMySqlContext(this IServiceCollection services,
            //                                         IConfiguration config)
            //{
            //    var connectionString = config["ConnectionStrings:DefaultConnection"];
            //    services.AddDbContext<TodoContext>(o => o.UseSqlServer(connectionString));

            //}
        }
    }
}
