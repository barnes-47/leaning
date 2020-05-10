using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using WebApi.Business.Concretes;
using WebApi.Business.Contracts;
using WebApi.Infrastructure.DataAccess;
using WebApi.Infrastructure.DataAccess.Base;
using WebApi.Infrastructure.DataAccess.Concretes;
using WebApi.Infrastructure.DataAccess.Contracts;
using WebApi.Infrastructure.Db.Context;
using WebApi.Infrastructure.Dto;

namespace WebApi
{
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddDbContext<ApplicationContext>(
                optionsBuilder =>
                {
                    optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ApplicationDb;Trusted_Connection=True;");
                });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork<ApplicationContext>, UnitOfWork<ApplicationContext>>();
            services.AddScoped<IUserBusiness, UserBusiness>();
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
