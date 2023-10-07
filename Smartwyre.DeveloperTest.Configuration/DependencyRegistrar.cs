using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Smartwyre.DeveloperTest.Configuration;

public class DependencyRegistrar
{
    public static IConfiguration ConfigurationRegistrar(IServiceCollection services)
    {
        var builder = new ConfigurationBuilder();

        var config = 
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        services.AddSingleton<IConfiguration>(config);
        
        return config;
    }
}