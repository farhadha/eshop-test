using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop
{
	public class Startup : object
	{
		public Startup() : base()
		{
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen(current =>
			{
				// **************************************************
				// Set the comments path for the Swagger JSON and UI.
				// File Name: Application.xml
				var xmlFile =
					$"{ System.Reflection.Assembly.GetExecutingAssembly().GetName().Name }.xml";

				var xmlPathName =
					System.IO.Path.Combine(System.AppContext.BaseDirectory, xmlFile);

				current.IncludeXmlComments(filePath: xmlPathName);
				// **************************************************

				current.SwaggerDoc
					(name: "v1",
					info: new Microsoft.OpenApi.Models.OpenApiInfo
					{
						Version = "v1",
						Title = "EShop Test",
						Description = "Restful Products"
					});
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();	
				app.UseSwagger();
				app.UseSwaggerUI(current =>
				{
					current.SwaggerEndpoint("/swagger/v1/swagger.json", "EShop v1");
				});
			}
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
