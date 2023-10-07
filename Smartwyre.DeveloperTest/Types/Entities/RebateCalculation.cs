using Smartwyre.DeveloperTest.Types.Entities;

namespace Smartwyre.DeveloperTest.Types;

public class RebateCalculation : BaseEntity
{
    public string Identifier { get; set; }
    public string RebateIdentifier { get; set; }
    public IncentiveType IncentiveType { get; set; }
    public decimal Amount { get; set; }
}
