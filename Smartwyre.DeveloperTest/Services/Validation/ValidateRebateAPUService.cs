using Smartwyre.DeveloperTest.Abstraction.Services;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Types.CalculateRebate;

namespace Smartwyre.DeveloperTest.Services.Validation;

public class ValidateRebateAPUService: IValidateRebateService
{
    public CalculateRebateValidationResult Validate(CalculateRebateValidationDto dto)
    {
        var result = new CalculateRebateValidationResult();

        if 
            (
                dto.Rebate == null ||
                dto.Product == null ||
                !dto.Product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom) ||
                dto.Rebate.Amount == 0 ||
                dto.Request.Volume == 0
            )
        {
            return result;
        }

        result.RebateAmount += dto.Rebate.Amount * dto.Request.Volume;
        result.Success = true;
        
        return result;
    }
}