using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using GoodsForecast.Scheduling.Model.BaseHandlers;
using Followers.Model.Clients;
using Followers.Model;
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

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDbContexts(services);
            ConfigureMediatR(services);
            ConfigureProjectServices(services);
            ConfigureControllers(services);


            // services.AddSingleton(typeof(IClientsManager), typeof(ClientsManager));

            TypeAdapterConfig.GlobalSettings.Default.MapToConstructor(true);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Followers.Api API", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Followers.Api API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureProjectServices(IServiceCollection services)
        {
            services.AddTransient<IClientsManager, ClientsManager>();
        }
        
        private void ConfigureMediatR(IServiceCollection services)
        {
            services.AddMediatR(GetType().Assembly);
            services.AddMediatR(typeof(AssemblyRepresentative).Assembly);
        }
        
        private void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers();
        }
        
        private void ConfigureDbContexts(IServiceCollection services)
        {
            services.AddDbContext<IFollowersDbContext, FollowersDbContext>();
        }
    }
}
