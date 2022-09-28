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

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(_categoryRepository.GetCategories());
    
        }

        public IActionResult Details(int id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
            return View(category);
        }


        // GET: Categories/Create
        public IActionResult Create()
        {
            return View(new Category());
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            try
            {
                category.CategoryId = Guid.NewGuid();
                _categoryRepository.InsertCategory(category);
                _categoryRepository.Save();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "");
            }
            return View(category);

        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Category category = _categoryRepository.GetCategoryById(id);
            return View(category);
        }
        // POST: Categories/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CategoryId,DeviceId,DeviceName,ZoneId,Status,IsActive,DateCreated")] Category category)
        {
            try
            {
                _categoryRepository.UpdateCategory(category);
                _categoryRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "");
               
            }
            return View(category);
 
            

        }

        public async Task<IActionResult> Delete(int id,bool?saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                return NotFound();
            }

            Category category = _categoryRepository.GetCategoryById(id);
            return View(category);
           
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                Category category = _categoryRepository.GetCategoryById(id);
                _categoryRepository.DeleteCategory(id);
                _categoryRepository.Save();


            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToActionPermanent(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }

        private bool CategoryExists(Category category, Guid id)
        {
                return _categoryRepository.GetCategories().Any(x => x.CategoryId == id);   
        }
   
    }
}
