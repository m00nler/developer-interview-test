using System.Collections.Generic;
using Moq;
using Smartwyre.DeveloperTest.Abstraction.DataStores;
using Smartwyre.DeveloperTest.Abstraction.Services;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Services.Validation;
using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Types.CalculateRebate;
using Smartwyre.DeveloperTest.Types.Entities;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests.PaymentService;

public class FCAValidateServiceTest
{
    private readonly Mock<IProductDataStore> _mockedProductDataStore = new();
    private readonly Mock<IRebateDataStore> _mockedRebateDataStore = new();

    private readonly IDictionary<IncentiveType, IValidateRebateService> _validateRebateServices =
        new Dictionary<IncentiveType, IValidateRebateService>()
        {
            { IncentiveType.AmountPerUom , new ValidateRebateAPUService()},
            { IncentiveType.FixedRateRebate , new ValidateRebateFRRService()},
            { IncentiveType.FixedCashAmount , new ValidateRebateFCAService()},
        };


    [Theory]
    [InlineData("test-identifier-product", "test-identifier-rebate", SupportedIncentiveType.FixedCashAmount, 10, 2, 2, true)] // Success case
    [InlineData("test-identifier-product", "test-identifier-rebate", SupportedIncentiveType.AmountPerUom, 10, 2, 2, false)] // Unsupported type
    [InlineData("test-identifier-product", "test-identifier-rebate", SupportedIncentiveType.FixedCashAmount, 10, 0, 2, false)] // Zero amount
    [InlineData(null, "test-identifier-rebate", SupportedIncentiveType.FixedCashAmount, 10, 2, 2, false)] // Null product
    [InlineData("test-identifier-product", null, SupportedIncentiveType.FixedCashAmount, 10, 2, 2, false)] // Null rebate
    public void CalculateRebate_Test(string productIdentifier, string rebateIdentifier,
        SupportedIncentiveType supportedIncentiveType, decimal percentage, decimal amount, int volume, bool expectedResult)
    {
        // arrange
        Product product = null;
        Rebate rebate = null;

        if (productIdentifier != null)
        {
            product = new Product
            {
                Id = 1,
                Identifier = productIdentifier,
                Uom = "test-uom-product",
                SupportedIncentives = supportedIncentiveType
            };
        }

        if (rebateIdentifier != null)
        {
            rebate = new Rebate
            {
                Id = 1,
                Identifier = rebateIdentifier,
                Incentive = IncentiveType.FixedCashAmount,
                Percentage = percentage,
                Amount = amount
            };
        }

        _mockedProductDataStore.Setup(ds => ds.GetProduct(productIdentifier)).Returns(product);
        _mockedRebateDataStore.Setup(ds => ds.GetRebate(rebateIdentifier)).Returns(rebate);

        var service = new RebateService(_mockedRebateDataStore.Object, _mockedProductDataStore.Object,
            _validateRebateServices);
        var request = new CalculateRebateRequest
        {
            Volume = volume,
            RebateIdentifier = rebateIdentifier,
            ProductIdentifier = productIdentifier
        };

        // act
        var response = service.Calculate(request);

        // assert
        Assert.NotNull(response);
        Assert.Equal(expectedResult, response.Success);
    }
}