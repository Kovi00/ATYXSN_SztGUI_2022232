using ATYXSN_HFT_2021222.Logic;
using ATYXSN_HFT_2021222.Models;
using ATYXSN_HFT_2021222.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATYXSN_HFT_2021222.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IMatchLogic, MatchLogic>();
            services.AddTransient<IBettorLogic, BettorLogic>();
            services.AddTransient<IBookmakerLogic, BookmakerLogic>();

            services.AddTransient<IRepository<Match>, MatchRepository>();
            services.AddTransient<IRepository<Bettor>, BettorRepository>();
            services.AddTransient<IRepository<Bookmaker>, BookmakerRepository>();

            services.AddTransient<MatchDbContext, MatchDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
