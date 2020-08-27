using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using HappyDevops.AutofacAndAspnetCore2.IoC.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HappyDevops.AutofacAndAspnetCore2
{
    public class Startup
    {
        public  ILifetimeScope Container { get; private set; } 

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddOptions();

            //Inicialización del contenedor
            var builder = new ContainerBuilder();
            builder.Populate(services);
            ComposeDependences(builder);
            Container = builder.Build();
            return  new AutofacServiceProvider(Container);
        }

        private void ComposeDependences(ContainerBuilder builder)
        {
            builder.RegisterModule<ModuleExample>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
