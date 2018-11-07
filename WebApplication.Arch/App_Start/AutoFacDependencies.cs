using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

using Application.Entities.Entities;

using WebApplication.Arch.Controllers;
using Application.Service;
using System.Data.Entity;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace WebApplication.Arch
{
    public static class AutoFacDependencies
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            /// Category Dependencies
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<Repository<Category>>().As<IRepositoryAsync<Category>> ();            
            builder.RegisterType<CategoryController>();

            /// Unit of work Dependencies
            builder.RegisterType<MyAppDbContext>().As<DbContext>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}