using System.Collections.Generic;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Core.IServices
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        Product CreateNewProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(int id);
    }
}