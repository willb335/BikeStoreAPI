using BikeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreAPI.Data
{
    public class SqlCategoriesRepo : ICategoriesRepo
    {
        private readonly BikeStoresContext _context;

        public SqlCategoriesRepo(BikeStoresContext context)
        {
            _context = context;
        }
        public void CreateCategories(Categories categories)
        {
            if (categories == null)
            {
                throw new ArgumentNullException(nameof(categories));
            }
            _context.Categories.Add(categories);
        }

        public void DeleteCategories(Categories categories)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Categories GetCategoriesById(int id)
        {
            return _context.Categories.FirstOrDefault(p => p.CategoryId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);  
        }

        public void UpdateCategories(Categories categories)
        {
            throw new NotImplementedException();
        }
    }
}
