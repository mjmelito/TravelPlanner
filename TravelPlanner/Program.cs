using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TravelPlanner.Models;
using Microsoft.AspNetCore.Identity;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace TravelPlanner
{
  class Program
  {
    static void Main(string[] args)
    {
      Task<string> apiCallTask = ApiHelper.ApiCall("[YOUR-API-KEY-HERE]");
      string result = apiCallTask.Result;
      Console.WriteLine(result);

      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

      builder.Services.AddControllersWithViews();

      builder.Services.AddDbContext<TravelPlannerContext>(
                        dbContextOptions => dbContextOptions
                          .UseMySql(
                            builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                          )
                        )
                      );

      builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TravelPlannerContext>()
                .AddDefaultTokenProviders();

      builder.Services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 0;
        options.Password.RequiredUniqueChars = 0;
      });
       
       
       

      WebApplication app = builder.Build();

      app.UseDeveloperExceptionPage();
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication(); 
      app.UseAuthorization();

      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");

      app.Run();
    }
      class ApiHelper
  {
    public static async Task<string> ApiCall(string apiKey)
    {
      RestClient client = new RestClient("https://tripadvisor16.p.rapidapi.com/api/v1/flights/searchAirport?query=london");
      RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
  }
}