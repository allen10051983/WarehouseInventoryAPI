using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WarehouseInventory.Models;
using WarehouseInventory.Services;

namespace WarehouseInventory.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_categoryService.GetAll());
        }

        public IHttpActionResult Get(int id)
        {
            var category = _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        public IHttpActionResult Post([FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input(s).");
            }
            if (category.Id > 0)
            {
                return BadRequest("This category cannot be created.");
            }

            try
            {
                _categoryService.Create(category);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Created<Category>("/api/categories", category);
        }

        public IHttpActionResult Put(int id, [FromBody] Category category)
        {
            if (id == 0 || id != category.Id)
            {
                return BadRequest("Invalid input(s)");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input(s)");
            }

            try
            {
                _categoryService.Update(category);
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
                _categoryService.Remove(id);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }
    }
}
