using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webapi.Models;
using Microsoft.EntityFrameworkCore;
using Webapi.Services;
using Webapi.Services.Implementations;

namespace Webapi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Services
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddEntityFrameworkNpgsql().AddDbContext<ApiContext>(options =>
        options.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"]));

      services.AddTransient<DataSeed>();

      services.AddScoped<ICustomersService, CustomersService>();
      services.AddScoped<IOrdersService, OrdersService>();
    }

    // Middlewares
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataSeed seed)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      seed.SeedData(20, 1000);

      app.UseHttpsRedirection();

      app.UseMvc(routes => routes.MapRoute("default", "api/{controller}/{action}/{id?}"));
    }
  }
}
