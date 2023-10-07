using Smartwyre.DeveloperTest.Types.CalculateRebate;
using Smartwyre.DeveloperTest.Types.Entities;

namespace Smartwyre.DeveloperTest.Abstraction.Services;

public interface IValidateRebateService
{
    CalculateRebateValidationResult Validate(CalculateRebateValidationDto dto);
}