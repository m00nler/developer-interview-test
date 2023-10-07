using Smartwyre.DeveloperTest.Types.Entities;

namespace Smartwyre.DeveloperTest.Abstraction.DataStores;

public interface IProductDataStore
{
    Product GetProduct(string productIdentifier);
}