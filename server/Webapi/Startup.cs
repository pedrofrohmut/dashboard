using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webapi.Models;
using Microsoft.EntityFrameworkCore;

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
      // services.AddDbContext<ApiContext>(options =>
      //   options.UseNpsql(Configuration["ConnectionStrings:DefaultConnection"]));
    }

    // Middlewares
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
