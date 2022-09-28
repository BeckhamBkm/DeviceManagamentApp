using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.GenericRepository;
using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        IEnumerable<Category> GetAllCategories();

        Category GetCategoryById(int categoryId);
        Category Find(int categoryId);

        void DeleteCategoryById(int categoryId);


        void UpdateCategory(Category category);

        void AddCategory(Category category);


        void Save();
        
    }

}
