using Smartwyre.DeveloperTest.Abstraction.Services;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Types.CalculateRebate;
using Smartwyre.DeveloperTest.Types.Entities;

namespace Smartwyre.DeveloperTest.Services.Validation;

public class ValidateRebateFRRService : IValidateRebateService
{
    public CalculateRebateValidationResult Validate(CalculateRebateValidationDto dto)
    {
        var result = new CalculateRebateValidationResult();
        
        if 
            (
                dto.Rebate == null || 
                dto.Product == null || 
                !dto.Product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate) ||
                dto.Rebate.Percentage == 0 || 
                dto.Product.Price == 0 || 
                dto.Request.Volume == 0
            )
        {
            return result;
        }
        
        result.RebateAmount += dto.Product.Price * dto.Rebate.Percentage * dto.Request.Volume;
        result.Success = true;

        return result;
    }
}