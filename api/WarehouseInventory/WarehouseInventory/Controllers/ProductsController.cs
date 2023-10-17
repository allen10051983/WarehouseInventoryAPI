using WarehouseInventory.Models;
using WarehouseInventory.Repositories;
using WarehouseInventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WarehouseInventory.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_productService.GetAll());
        }

        public IHttpActionResult Get(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IHttpActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input(s).");
            }
            if (product.Id > 0)
            {
                return BadRequest("This product cannot be created.");
            }

            try
            {
                _productService.Create(product);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Created<Product>("/api/product", product);
        }

        public IHttpActionResult Put(int id, [FromBody] Product product)
        {
            if (id == 0 || id != product.Id)
            {
                return BadRequest("Invalid input(s)");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input(s)");
            }

            try
            {
                _productService.Update(product);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                _productService.Remove(id);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }
    }
}