using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using acidfox_api.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;


namespace acidfox_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // public void ConfigureServices(IServiceCollection services)
        // {
        //     services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
        //     var connection = "Data Source=acidfox.db";
        //     services.AddDbContext<MemberContext>
        //         (options => options.UseNpgsql(connection));

        // }
        
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<AcidFoxContext>()
                    .BuildServiceProvider();
        }
            

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors(
                options => options
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader()
            );
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // services.AddCors(options =>
            // {
            //     options.AddPolicy("AllowSpecificOrigin", builder => builder
            //                         .WithOrigins("http://localhost:3000")
            //                         .AllowAnyMethod() 
            //                         .AllowCredentials();
            // });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
