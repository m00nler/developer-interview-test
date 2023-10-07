using Smartwyre.DeveloperTest.Types.CalculateRebate;

namespace Smartwyre.DeveloperTest.Abstraction.Services;

public interface IRebateService
{
    CalculateRebateResult Calculate(CalculateRebateRequest request);
}
