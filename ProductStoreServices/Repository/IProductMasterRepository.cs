using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStoreServices.Repository
{
    public interface IProductMasterRepository
    {
        List<Items> GetProductList();
        Item GetProduct(int id);
        bool AddProduct(Item _item);
        bool UpdateProduct(Item item);
        bool DeleteProduct(int id);
        List<Items> SearchProductList(string searchTerm);

    }
}
