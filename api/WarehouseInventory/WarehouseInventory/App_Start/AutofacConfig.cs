using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WarehouseInventory.Models.Entities;
using WarehouseInventory.Repositories;
using WarehouseInventory.Services;

namespace WarehouseInventory.App_Start
{
    public static class AutofacConfig
    {
        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<ProductService>().As<IProductService>();
           

            builder.RegisterType<ApplicationDbContext>().As<ApplicationDbContext>();

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver
                = new AutofacWebApiDependencyResolver(container);
        }
    }
}