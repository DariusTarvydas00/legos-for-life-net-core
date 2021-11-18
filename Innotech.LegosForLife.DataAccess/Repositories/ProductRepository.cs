using System.Collections.Generic;
using System.IO;
using System.Linq;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.DataAccess.Entities;
using InnoTech.LegosForLife.Domain.IRepositories;

namespace InnoTech.LegosForLife.DataAccess.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly MainDbContext _ctx;

        public ProductRepository(MainDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Product Repository Must have a DBContext");
            _ctx = ctx;
        }
        public List<Product> FindAll()
        {
            return _ctx.Products
                .Select(pe => new Product
                {
                    Id = pe.Id,
                    Name = pe.Name
                })
                .ToList();
        }

        public Product GetProductById(int id)
        {
            return _ctx.Products.Select(pe => new Product()
            {
                Id = pe.Id,
                Name = pe.Name
            }).FirstOrDefault(product => product.Id == id);
        }

        public Product CreateNewProduct(Product product)
        {
            var entity = _ctx.Products.Add(new ProductEntity()
            {
                Id = product.Id,
                Name = product.Name
            }).Entity;
            _ctx.SaveChanges();
            return new Product()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Product UpdateProduct(Product product)
        {
            var entity = _ctx.Products.Update(new ProductEntity()
            {
                Id = product.Id,
                Name = product.Name
            }).Entity;
            _ctx.SaveChanges();
            return new Product()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Product DeleteProduct(int id)
        {
            var entity = _ctx.Products.Remove(new ProductEntity()
            {
                Id = id
            }).Entity;
            _ctx.SaveChanges();
            return new Product() {Id = entity.Id};
        }
    }
}