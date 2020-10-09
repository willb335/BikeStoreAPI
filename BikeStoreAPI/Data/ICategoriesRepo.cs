using BikeStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreAPI.Data
{
    public interface ICategoriesRepo
    {
         
        bool SaveChanges();
        IEnumerable<Categories> GetAllCategories();
        Categories GetCategoriesById(int id);
        void CreateCategories(Categories categories);
        void UpdateCategories(Categories categories);
        void DeleteCategories(Categories categories);
    
}
}
