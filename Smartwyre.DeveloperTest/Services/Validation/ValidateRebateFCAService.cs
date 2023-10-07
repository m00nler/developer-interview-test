using System;
using Smartwyre.DeveloperTest.Abstraction.Services;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Types.CalculateRebate;
using Smartwyre.DeveloperTest.Types.Entities;

namespace Smartwyre.DeveloperTest.Services.Validation;

public class ValidateRebateFCAService : IValidateRebateService
{
    public CalculateRebateValidationResult Validate(CalculateRebateValidationDto dto)
    {
        var result = new CalculateRebateValidationResult();
        
        if 
            (
                dto.Rebate == null ||
                dto.Product == null ||
                !dto.Product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount) ||
                dto.Rebate.Amount == 0
            )
        {
            result.Success = false;
        }
        else
        {
            result.RebateAmount = dto.Rebate.Amount;
            result.Success = true;
        }

        return result;
    }
}