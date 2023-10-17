using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseInventory.Models.Entities;

namespace WarehouseInventory.Repositories
{
    public interface IProductRepository : IRepositoryBase<ProductEntity>
    {
    }
}