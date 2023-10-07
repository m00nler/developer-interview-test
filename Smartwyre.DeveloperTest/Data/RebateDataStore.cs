using System.Linq;
using Smartwyre.DeveloperTest.Abstraction.DataStores;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Types.Entities;
using RebateCalculation = Smartwyre.DeveloperTest.Types.RebateCalculation;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore : IRebateDataStore
{
    private readonly SmartwyreContext _smartwyreContext;

    public RebateDataStore(SmartwyreContext smartwyreContext)
    {
        _smartwyreContext = smartwyreContext;
    }

    public Rebate GetRebate(string rebateIdentifier)
    {
        return _smartwyreContext.Rebates.FirstOrDefault((r) => r.Identifier.Equals(rebateIdentifier));
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        var calculation = new RebateCalculation
        {
            IncentiveType = account.Incentive,
            RebateIdentifier = account.Identifier,
            Amount = rebateAmount
        };

        _smartwyreContext.RebateCalculations.Add(calculation);
        _smartwyreContext.SaveChanges();
    }
}
