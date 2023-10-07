using Smartwyre.DeveloperTest.Types.Entities;

namespace Smartwyre.DeveloperTest.Abstraction.DataStores;

public interface IRebateDataStore
{
    Rebate GetRebate(string rebateIdentifier);

    void StoreCalculationResult(Rebate account, decimal rebateAmount);
}