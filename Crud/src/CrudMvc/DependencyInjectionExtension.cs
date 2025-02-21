using CrudMvc.Context;
using Microsoft.EntityFrameworkCore;

namespace CrudMvc;

public static class DependencyInjectionExtension
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
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