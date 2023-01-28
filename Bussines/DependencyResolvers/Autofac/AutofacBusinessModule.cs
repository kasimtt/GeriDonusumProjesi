using Autofac;
using Autofac.Extras.DynamicProxy;
using Bussines.Abstract;
using Bussines.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.DependencyResolvers.Autofac
{
     public class AutofacBusinessModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<GarbageManager>().As<IGarbageService>().SingleInstance();
                builder.RegisterType<EfGarbageDal>().As<IGarbageDal>().SingleInstance();

                builder.RegisterType<CarbonToKYCManager>().As<ICarbonToKYCService>().SingleInstance();
                builder.RegisterType<EfCarbonToKYCDal>().As<ICarbonToKYCDal>().SingleInstance();

                builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
                builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
    
}
