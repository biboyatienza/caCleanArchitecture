using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
      // I used Sqlite here;
      services.AddDbContext<ApplicationDBContext>(options => 
        options.UseSqlite(configuration.GetConnectionString("CleanArchContextSQLite"), 
        b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)), ServiceLifetime.Transient);

      services.AddScoped<IApplicationBDContext>(provider => provider.GetService<ApplicationDBContext>());
      return services;  
    }
  }
}