using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseInventory.Models.Entities;

namespace WarehouseInventory.Repositories
{
    public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}