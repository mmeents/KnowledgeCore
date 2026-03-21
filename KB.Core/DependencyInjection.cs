using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace KB.Core {
  public static class DependencyInjection {

    public static IServiceCollection AddKbCore<TContext>(
      this IServiceCollection services, 
      IConfiguration configuration) 
      where TContext : KbDbContext {
      services.AddDbContext<TContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

     // services.AddScoped<KbDbContext>(sp => sp.GetRequiredService<TContext>());

      services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            

      return services;
    }
    
  }
}
