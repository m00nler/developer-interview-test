using System;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Abstraction.Services;
using Smartwyre.DeveloperTest.Types.CalculateRebate;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = Startup.StartApp();
        
        Console.WriteLine("Please, enter Rebate Identifier:");
        Console.WriteLine("Waiting for an answer...");
        var rebateIdentifier = Console.ReadLine();

        Console.WriteLine("Please, enter Product Identifier:");
        Console.WriteLine("Waiting for an answer...");
        var productIdentifier = Console.ReadLine();

        Console.WriteLine("Please, enter Volume:");
        Console.WriteLine("Waiting for an answer...");
        var volumeStr = Console.ReadLine();

        if (!decimal.TryParse(volumeStr, out var volume))
        {
            Console.WriteLine("Invalid volume");
            
            return;
        }

        var service = serviceProvider.GetRequiredService<IRebateService>();
        var request = new CalculateRebateRequest
        {
            RebateIdentifier = rebateIdentifier,
            ProductIdentifier = productIdentifier,
            Volume = volume
        };
        
        var response = service.Calculate(request);
        Console.WriteLine("Response: ", response.Success);
    }
}
