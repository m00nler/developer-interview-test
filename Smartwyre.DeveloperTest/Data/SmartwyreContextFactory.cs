using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Smartwyre.DeveloperTest.Configuration;

namespace Smartwyre.DeveloperTest.Data;

public class SmartwyreContextFactory : IDesignTimeDbContextFactory<SmartwyreContext>
{

    public SmartwyreContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SmartwyreContext>();
        Console.Write("Enter your connection string: ");
        var conStr = Console.ReadLine();
        
        optionsBuilder.UseNpgsql(conStr);

        return new SmartwyreContext(optionsBuilder.Options);
    }
}