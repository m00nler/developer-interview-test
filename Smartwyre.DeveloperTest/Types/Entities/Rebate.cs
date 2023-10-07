namespace Smartwyre.DeveloperTest.Types.Entities;

public class Rebate : BaseEntity
{
    public string Identifier { get; set; }
    public IncentiveType Incentive { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }
}
