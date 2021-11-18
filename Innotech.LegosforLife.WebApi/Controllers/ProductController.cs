using System;
using System.Collections.Generic;
using System.IO;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.WebApi.DTOs;
using InnoTech.LegosForLife.WebApi.DTOs.ProductDtos;
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

        [HttpPost]
        public ActionResult<PostProductDto> PostProductDto([FromBody]PostProductDto dto)
        {
            var productDto = new Product()
            {
                Name = dto.Name
            };
            try
            {
                var newProduct = _productService.CreateNewProduct(productDto);
                return Created($"https://localhost:5001/api/videos/{newProduct.Id}", newProduct);
            }
            catch (ArgumentException e)
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        public ActionResult<PutProductDto> PutProductDto(int id, [FromBody] PutProductDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            return Ok(_productService.UpdateProduct(new Product()
            {
                Id = dto.Id,
                Name = dto.Name
            }));
        }
    }
}