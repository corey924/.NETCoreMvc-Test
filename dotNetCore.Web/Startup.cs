using dotNetCore.Services.Database.Entity;
using dotNetCore.Services.Interfaces;
using dotNetCore.Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace dotNetCore
{
  public class Startup
  {
    private readonly IConfiguration _config;
    public Startup(IConfiguration configuration)
    {
      _config = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      double loginExpireMinute = _config.GetValue<double>("Login:LoginExpireMinute");
      string loginPath = _config.GetValue<string>("Login:LoginPath");
      string logoutPath = _config.GetValue<string>("Login:LogoutPath");

      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddDbContext<EntityDbContext>(options => options.UseSqlServer(_config.GetConnectionString("Database")));

      services.AddScoped<IUserService, UserService>();

      services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
      {
        // 登入
        option.LoginPath = new PathString(loginPath);
        // 登出
        option.LogoutPath = new PathString(logoutPath);
        // 登入逾期，或Controller中用戶登入時也可設定，沒給預設14天
        option.ExpireTimeSpan = TimeSpan.FromMinutes(loginExpireMinute);
      });

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/main/error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();
      app.UseAuthentication();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=login}/{action=index}/{id?}");
      });
    }
  }
}
