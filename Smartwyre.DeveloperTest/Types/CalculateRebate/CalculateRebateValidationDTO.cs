using Smartwyre.DeveloperTest.Types.Entities;

namespace Smartwyre.DeveloperTest.Types.CalculateRebate;

public class CalculateRebateValidationDto
{
    public Rebate Rebate { get; set; }
    public Product Product { get; set; }
    public CalculateRebateRequest Request { get; set; }

    public CalculateRebateValidationDto()
    {
        
    }
}