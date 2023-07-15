using Microsoft.AspNetCore.Mvc;
using TicketDispenserAPI.Providers;
using TicketDispenserAPI.Repositories;
using TicketDispenserAPI.Services;

namespace TicketDispenserAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;           
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigureApiVersioning(services);
            ConfigureSwagger(services);
            RegisterProjectDependencies(services);
        }       

        private void ConfigureApiVersioning(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private void RegisterProjectDependencies(IServiceCollection services)
        {
            services.AddSingleton<ITicketNumberRepository, TicketNumberRepository>();
            services.AddScoped<ITicketService, TicketService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseRouting();                       

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    
}
