using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.GenericRepository;
using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(Guid categoryId);
        void InsertCategory(Category category);
        void DeleteCategory(Guid categoryId);
        void UpdateCategory(Category category);
        void Save();
       
    }
}
