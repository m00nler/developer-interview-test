using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Abstraction.Services;
using Smartwyre.DeveloperTest.Configuration;
using Smartwyre.DeveloperTest.Services.Validation;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Runner;

public class Startup
{
    public static IServiceProvider StartApp()
    {
        var services = new ServiceCollection();

        var config = Smartwyre.DeveloperTest.Configuration.DependencyRegistrar.ConfigurationRegistrar(services);

        DependencyRegistrar.DbContextRegistrar(services, config);
        
        DependencyRegistrar.DataStoresRegistrar(services);

        DependencyRegistrar.ServicesRegistrar(services);

        return services.BuildServiceProvider();
    }
}