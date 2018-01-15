using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doctor.API.Infrastructure.Filters;
using Doctor.API.Services;
using Doctor.Core;
using Doctor.Core.Network;
using Doctor.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Doctor.API
{
	public class Startup
	{
		private IConfiguration Configuration;

		public Startup(IConfiguration configuration, IHostingEnvironment environment)
		{
			var builder = new ConfigurationBuilder()
			              .SetBasePath(environment.ContentRootPath)
			              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			              .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
			              .AddEnvironmentVariables();

			Configuration = builder.Build();

		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper();
			services.AddMvc(options =>
			                {
				                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
			                });

			services.Configure<AppSettings>(Configuration);

			//Doctor.API
			services.AddTransient<IAvailabilityViewModelService, AvailabilityViewModelService>();

			//Doctor.Core
			services.AddSingleton<IHttpClient, StandardHttpClient>();
			services.AddTransient<IAvailabilityService, AvailabilityService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			app.UseDefaultFiles();
			app.UseMvc();
		}
	}
}
