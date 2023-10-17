using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseInventory.Mappers;
using WarehouseInventory.Models;
using WarehouseInventory.Models.Entities;
using WarehouseInventory.Repositories;

namespace WarehouseInventory.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            var entities = _productRepository.GetAll().ToList();
            var result = new List<Product>();

            foreach (var entity in entities)
            {
                result.Add(ProductMapper.FromEntity(entity));
            }
            return result;
        }

        public Product GetById(int id)
        {
            var entity = _productRepository.Get(id);
            return ProductMapper.FromEntity(entity);
        }

        public void Create(Product product)
        {
            var entity = new ProductEntity();
            ProductMapper.ToEntity(product, entity);
            _productRepository.Create(entity);
            product.Id = entity.Id;
        }

        public void Update(Product product)
        {
            var entity = _productRepository.Get(product.Id);
            ProductMapper.ToEntity(product, entity);
            _productRepository.Update(entity);
        }

        public void Remove(int id)
        {
            _productRepository.Delete(id);
        }
    }
}