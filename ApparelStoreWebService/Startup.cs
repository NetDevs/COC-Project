using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreWebService.Components;
using ApparelStoreWebService.Models.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApparelStoreWebService
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                       {
                           builder.WithOrigins("http://localhost:50816")
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                       }));
            //same domain Policy
         
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ApparelStoreContext>(c => c.UseSqlServer(Configuration.GetConnectionString("ApparelConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            logger.AddFile("d:\\logfile.txt", LogLevel.Error);

            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
                
            }
            app.UseMiddleware(typeof(ExceptionHandlingServiceMiddleware));
            app.UseCors("MyPolicy");
            app.UseMvc();
        }
    }
}
