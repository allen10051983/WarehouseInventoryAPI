using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseInventory.Models;
using WarehouseInventory.Models.Entities;

namespace WarehouseInventory.Mappers
{
    public static class CategoryMapper
    {
        public static Category FromEntity(CategoryEntity entity)
        {
            return new Category
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public static void ToEntity(Category vm, CategoryEntity entity)
        {
            entity.Name = vm.Name;
        entity.Description = vm.Description;
        }
    }
}