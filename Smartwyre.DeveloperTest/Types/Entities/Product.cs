namespace Smartwyre.DeveloperTest.Types.Entities;

public class Product : BaseEntity
{
    public string Identifier { get; set; }
    public decimal Price { get; set; }
    public string Uom { get; set; }
    public SupportedIncentiveType SupportedIncentives { get; set; }
}
