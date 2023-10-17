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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAll()
        {
            var allEntities = _categoryRepository.GetAll();
            var result = new List<Category>();
            foreach (var entity in allEntities)
            {
                var categoryVm = CategoryMapper.FromEntity(entity);
                result.Add(categoryVm);
            }
            return result;
        }

        public Category GetById(int id)
        {
            var entity = _categoryRepository.Get(id);

            return CategoryMapper.FromEntity(entity);
        }

        public void Create(Category category)
        {
            var entity = new CategoryEntity();
            CategoryMapper.ToEntity(category, entity);
            _categoryRepository.Create(entity);
            category.Id = entity.Id;
        }

        public void Update(Category category)
        {
            var entity = _categoryRepository.Get(category.Id);
            CategoryMapper.ToEntity(category, entity);
            _categoryRepository.Update(entity);
        }

        public void Remove(int id)
        {
            _categoryRepository.Delete(id);
        }
    }
}