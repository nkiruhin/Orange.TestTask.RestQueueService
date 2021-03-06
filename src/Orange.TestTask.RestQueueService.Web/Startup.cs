using System;
using Ardalis.ListStartupServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Orange.TestTask.RestQueueService.Core;
using Orange.TestTask.RestQueueService.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatR;

namespace Orange.TestTask.RestQueueService.Web
{
    public class Startup
	{
		private readonly IWebHostEnvironment _env;

		public Startup(IConfiguration config, IWebHostEnvironment env)
		{
			Configuration = config;
			_env = env;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			string connectionString = Configuration.GetConnectionString("SqliteConnection");  //Configuration.GetConnectionString("DefaultConnection");
			string rebbitConnectionString = Configuration.GetConnectionString("RabbitConnection");  //Configuration.GetConnectionString("DefaultConnection");
			services.AddCore();
			services.AddMediatR(GetAppAssembly());
			services.AddInfrastructure(options =>
				{
					options.DbConnectionString = connectionString; 
					options.QueueConnectionString = rebbitConnectionString; 
				});

			services.AddControllers().AddNewtonsoftJson();

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Orange.TestTask.RestQueueService API", Version = "v1" });
				c.EnableAnnotations();
			});

			// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
			services.Configure<ServiceConfig>(config =>
			{
				config.Services = new List<ServiceDescriptor>(services);

				// optional - default path to view services is /listallservices - recommended to choose your own path
				config.Path = "/listservices";
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.EnvironmentName == "Development")
			{
				app.UseDeveloperExceptionPage();
				app.UseShowAllServicesMiddleware();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			app.UseRouting();

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}

        private Assembly[] GetAppAssembly()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.IsDynamic == false)
                .Where(x => x.FullName?.StartsWith("Orange.TestTask.RestQueueService") == true)
                .ToArray();

            return assemblies;
        }
	}
}
