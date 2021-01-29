using System;
using Wyklad3.DAL;
using Wyklad3.Middleware;
using Wyklad3.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using cw6.Services;
using Microsoft.Extensions.Hosting;
using Wyklad3.Models;

namespace Wyklad3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IStudentDbService, SqlServerStudentDbService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStudentDbService dbService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<LoggingMiddleware>();
            app.UseWhen(context => context.Request.Path.ToString().Contains("eska"), app =>
            {
                app.Use(async (context, next) =>
                {
                    if (!context.Request.Headers.ContainsKey("Index"))
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("brak indeksu");
                        return;
                    }

                    Student student = dbService.GetStudent(context.Request.Headers["Index"].ToString());
                    if (student == null)
                    {
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        await context.Response.WriteAsync("nie ma studenta otym indeksie");
                        return;
                    }
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    await context.Response.WriteAsync(student.ToString());
                    await next();
                });
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}