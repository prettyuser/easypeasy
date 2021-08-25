using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Followers.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Followers.Model.Clients;
using GoodsForecast.Scheduling.Model.BaseHandlers;
using Mapster;
using MediatR;

namespace Followers
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
            ConfigureControllers(services);
            
            services.AddSingleton(typeof(IClientsManager), typeof(ClientsManager));
            
            services.AddMediatR(GetType().Assembly);
            services.AddMediatR(typeof(AssemblyRepresentative).Assembly); 

            services.AddControllers();
            TypeAdapterConfig.GlobalSettings.Default.MapToConstructor(true);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Followers", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Followers v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
            });
        }
        
        private void ConfigureControllers(IServiceCollection services)
        {
            var mvcBuilder = services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic);
                    options.JsonSerializerOptions.WriteIndented = false;
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
                });
            
            services.AddOData();   
        }
        
        private void ConfigureDbContexts(IServiceCollection services)
        {
            var mainDbConnectionString = Configuration.GetConnectionString(nameof(ConnectionStrings.Main));     // ������ ����������� � �������� ��

            services.AddDbContext<FollowersDbContext>();
        }
    }
}