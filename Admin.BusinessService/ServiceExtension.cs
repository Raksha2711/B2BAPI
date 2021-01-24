using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace B2b.BusinessService
{
    public static class ServiceExtension
    {
        public static void ConfigureBusinessService(this IServiceCollection services)
        {
            //services.AddScoped<IRepository, Repository>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISubCategoryService, SubCategoryService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IServiceService, ServiceService>();
        }

    }
}
