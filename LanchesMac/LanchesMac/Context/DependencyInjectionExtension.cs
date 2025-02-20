using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddAppDbContext(services, configuration);
    }

    private static void AddAppDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("A string de conexão 'DefaultConnection' está ausente ou vazia.");
        
        services.AddDbContext<AppDbContext>(config => 
            config.UseSqlServer(connectionString));

    }
}