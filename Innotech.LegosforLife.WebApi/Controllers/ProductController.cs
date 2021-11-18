using System.Collections.Generic;
using System.IO;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new InvalidDataException("ProductService Cannot Be Null");
        }
        
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return _productService.GetProducts();
        }
        
        [HttpGet("{id}")]
        public ActionResult<GetProductByIdDto> GetProductByIdDto(int id)
        {
            var product = _productService.GetProductById(id);
            if (product is not null)
            {
                return Ok(new GetProductByIdDto()
                {
                    Id = product.Id,
                    Name = product.Name
                });
            }
            return NotFound();
        }
    }
}