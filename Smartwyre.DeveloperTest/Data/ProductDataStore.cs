using Smartwyre.DeveloperTest.Abstraction.DataStores;
using Smartwyre.DeveloperTest.Types.Entities;

namespace Smartwyre.DeveloperTest.Data;

public class ProductDataStore : IProductDataStore
{
    public Product GetProduct(string productIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        return new Product();
    }
}
