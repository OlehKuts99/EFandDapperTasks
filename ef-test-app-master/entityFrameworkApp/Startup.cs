using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperPersistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence;

namespace entityFrameworkApp
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IHostingEnvironment currentEnvironment)
    {
      Configuration = configuration;
      CurrentEnvironment = currentEnvironment;
    }

    public IConfiguration Configuration { get; }
    public IHostingEnvironment CurrentEnvironment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddScoped<IDapperService, DapperService>();
      var dbConnectionString = Configuration.GetConnectionString("ConnectionString");
      services.AddDbContext<OrderContext>(options => options.UseSqlServer(dbConnectionString));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();

      using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetRequiredService<OrderContext>();
        context.Database.EnsureCreated();
      }
    }
  }
}
