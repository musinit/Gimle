using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gimle;
using Gimle.Core;
using Gimle.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HomeTabExample
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
            services.AddGimleLib("your_app_token_here", 
                "your_workspace_api_here",options =>
                {
                    options.AddHandler("show_sparrow_action", typeof(ShowSparrowHandler));
                    options.AddHandler("show_crow_action", typeof(ShowCrowHandler));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GimleClient gimleClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseGimle();
            
            gimleClient.UpdateHomeAsync("U631X4HNY", "profile_with_sparrow");
        }
    }
}