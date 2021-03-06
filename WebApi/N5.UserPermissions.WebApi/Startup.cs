using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using N5.UserPermissions.Context;
using N5.UserPermissions.Service.Implementation;
using N5.UserPermissions.Service.Interface;
using N5.UserPermissions.UnitOfWork.Interface;

namespace N5.UserPermissions.WebApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "N5.UserPermissions.WebApi", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                    )
                );
            services.AddTransient<IUnitOfWork, UnitOfWork.Implementation.UnitOfWork>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IPermissionTypeService, PermissionTypeService>();

            services.AddCors(options =>
            {
                var webAppReactUrl = Configuration.GetValue<string>("ExternalUrl:WebAppReactUrl");
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(webAppReactUrl).AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "N5.UserPermissions.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
