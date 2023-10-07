using System;
using System.Collections.Generic;
using Smartwyre.DeveloperTest.Abstraction.DataStores;
using Smartwyre.DeveloperTest.Abstraction.Services;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Types.CalculateRebate;
using Smartwyre.DeveloperTest.Types.Entities;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IRebateDataStore _rebateDataStore;
    private readonly IProductDataStore _productDataStore;
    private readonly IDictionary<IncentiveType, IValidateRebateService> _validateRebateServices;


    public RebateService(
        IRebateDataStore rebateDataStore,
        IProductDataStore productDataStore,
        IDictionary<IncentiveType, IValidateRebateService> validateRebateServices
    )
    {
        _rebateDataStore = rebateDataStore;
        _productDataStore = productDataStore;
        _validateRebateServices = validateRebateServices;
    }
    
    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        var rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
        var product = _productDataStore.GetProduct(request.ProductIdentifier);

        if (rebate is null || product is null)
        {
            return new CalculateRebateResult()
            {
                Success = false
            };
        }

        if(!_validateRebateServices.TryGetValue(rebate.Incentive, out var service))
        {
            throw new KeyNotFoundException();
        }

        var result = service.Validate(new CalculateRebateValidationDto()
        {
            Product = product,
            Rebate = rebate,
            Request = request
        });

        if (result.Success)
        {
            _rebateDataStore.StoreCalculationResult(rebate, result.RebateAmount);
        }

        return new CalculateRebateResult()
        {
            Success = result.Success
        };
    }
}
