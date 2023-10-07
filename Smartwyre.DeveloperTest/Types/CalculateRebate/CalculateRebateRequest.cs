namespace Smartwyre.DeveloperTest.Types.CalculateRebate;

public class CalculateRebateRequest
{
    public string RebateIdentifier { get; set; }

    public string ProductIdentifier { get; set; }

    public decimal Volume { get; set; }
}
