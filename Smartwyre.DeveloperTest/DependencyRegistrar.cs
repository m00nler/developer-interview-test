using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Abstraction.DataStores;
using Smartwyre.DeveloperTest.Abstraction.Services;
using Smartwyre.DeveloperTest.Configuration;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Services.Validation;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest;

public class DependencyRegistrar
{
    public static void DbContextRegistrar(IServiceCollection services, IConfiguration configuration)
    {
        var appSettings = new AppSettings();

        configuration.GetSection("AppSettings").Bind(appSettings);

        services.AddDbContext<SmartwyreContext>(options =>
        {
            options.UseNpgsql(appSettings.ConnectionString);
        });
    }

    public static void DataStoresRegistrar(ServiceCollection services)
    {
        services.AddScoped<IProductDataStore, ProductDataStore>();
        services.AddScoped<IRebateDataStore, RebateDataStore>();
    }

    public static void ServicesRegistrar(IServiceCollection services)
    {
        services.AddScoped<ValidateRebateFCAService>();
        services.AddScoped<ValidateRebateFRRService>();
        services.AddScoped<ValidateRebateAPUService>();
        
        services.AddScoped<IDictionary<IncentiveType, IValidateRebateService>>(
            serviceProvider => new Dictionary<IncentiveType, IValidateRebateService>
                {
                    { IncentiveType.FixedCashAmount, serviceProvider.GetRequiredService<ValidateRebateFCAService>() },
                    { IncentiveType.FixedRateRebate, serviceProvider.GetRequiredService<ValidateRebateFRRService>() },
                    { IncentiveType.AmountPerUom, serviceProvider.GetRequiredService<ValidateRebateAPUService>() },
                }
        );
        

        services.AddScoped<IRebateService, RebateService>();
    }
}