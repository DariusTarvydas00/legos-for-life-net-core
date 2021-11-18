using System.Collections.Generic;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Domain.IRepositories
{
    public interface IProductRepository
    {
        List<Product> FindAll();
        Product GetProductById(int Id);
        Product CreateNewProduct(Product product);
        Product UpdateProduct(Product product);
    }
}