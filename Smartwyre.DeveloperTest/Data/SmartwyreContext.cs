using Microsoft.EntityFrameworkCore;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Types.Entities;

namespace Smartwyre.DeveloperTest.Data;

public class SmartwyreContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Rebate> Rebates { get; set; }
    
    public DbSet<RebateCalculation> RebateCalculations { get; set; }

    public SmartwyreContext(DbContextOptions<SmartwyreContext> options) : base(options)
    { }
}