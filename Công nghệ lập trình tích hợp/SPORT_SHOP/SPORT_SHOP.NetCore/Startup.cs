using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Implementations;
using CommonLib.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SPORT_SHOP.NetCore.Areas.Admin.Implementations;
using SPORT_SHOP.NetCore.Areas.Admin.Interfaces;

namespace SPORT_SHOP.NetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // web api

            services.AddTransient<IApiDataSportShopHandler, CApiDataSportShopHandler>();
            services.AddSingleton<IS6GApp>(CS6GFactory.GetS6GAppInstance());

            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Sport_Shop !");
            });
        }
    }
}
