using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseInventory.Models;
using WarehouseInventory.Models.Entities;

namespace WarehouseInventory.Mappers
{
   
        public static class ProductMapper
        {
            public static Product FromEntity(ProductEntity entity)
            {
                return new Product
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                   
                    Quantity = entity.Quantity,
                    Category = CategoryMapper.FromEntity(entity.Category)
                };
            }

            public static void ToEntity(Product vm, ProductEntity entity)
            {
                entity.Name = vm.Name;
                entity.Description = vm.Description;
                
                entity.Quantity = vm.Quantity;
                entity.CategoryId = vm.Category.Id;
            }
        }
    }