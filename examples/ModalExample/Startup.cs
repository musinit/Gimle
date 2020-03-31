using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gimle;
using Gimle.Core;
using Gimle.Core.Extensions;
using Gimle.Core.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ModalExample
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
                    options.AddHandler("meaning_of_life_action", typeof(MeaningOfLifeHandler));
                    options.AddHandler("meaning_of_life_modal", typeof(SaveMeaningOfLifeHandler));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseGimle();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
        }
    }
}