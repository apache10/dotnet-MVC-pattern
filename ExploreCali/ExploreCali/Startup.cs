﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCali.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExploreCali
{
    public class Startup
    { 
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfigurationRoot configuration;
        public Startup(IHostingEnvironment env)
        {
            configuration = new ConfigurationBuilder()
                                .AddEnvironmentVariables()
                                .AddJsonFile(env.ContentRootPath + "/config.json")
                                .AddJsonFile(env.ContentRootPath + "/config.development.json", true)
                                .Build();
            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FormattingService>();
            services.AddTransient<SpecialDataContext>();
            services.AddTransient<FeatureToggles>(x => new FeatureToggles
            {
                EnableDeveloperExceptions =
                    configuration.GetValue<bool>("FeatureToggles:EnableDeveloperExceptions")
            });
            services.AddMvc();

            services.AddDbContext<BlogDataContext>(options => 
            {
                var connectingString = configuration.GetConnectionString("BlogDataContext");
                options.UseSqlServer(connectingString);   
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FeatureToggles feature)
        {
            app.UseExceptionHandler("/error.html");

            //if (configuartion.GetValue<bool>("EnabledDeveloperEceptions"))
            if(feature.EnableDeveloperExceptions)
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                if(context.Request.Path.Value.StartsWith("/invalid"))
                {
                    throw new Exception("Error!");
                }
                await next();
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute("Default",
                                "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseFileServer();
        }
    }
}
