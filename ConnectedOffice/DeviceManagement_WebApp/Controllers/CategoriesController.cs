using System;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Authorization;
namespace DeviceManagement_WebApp.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoriesController(ICategoryRepository CategoryRepository)
        {
            _categoryRepository = CategoryRepository;
        }

        // GET: Category
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _categoryRepository.GetCategories();
            return View(categories);
        }


       // GET: Category/Details/5
        public IActionResult Details(Guid id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


       // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.InsertCategory(category);
                _categoryRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        
       // GET: Category/Edit/5
        public IActionResult Edit(Guid id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
       
       // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(category);
                _categoryRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

       // GET: Category/Delete/5
        public IActionResult Delete(Guid id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
            if (category != null)
            {
                _categoryRepository.DeleteCategory(id);
                _categoryRepository.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(Category category, Guid id)
        {
                return _categoryRepository.GetCategories().Any(x => x.CategoryId == id);   
        }
   
    }
}
