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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategories(Categories categories)
        {
            throw new NotImplementedException();
        }
    }
}
