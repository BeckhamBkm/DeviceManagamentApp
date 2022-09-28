using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.GenericRepository;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        private readonly ConnectedOfficeContext _context;

        public CategoryRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategory()
        {
            return _context.Category.ToList();
        }

        public Category GetCategoryByID(int id)
        {
            return _context.Category.Find(id);
        }

        public void InsertStudent(Category category)
        {
            _context.Category.Add(category);
        }

        public void DeleteStudent(int categoryID)
        {
            Category category = _context.Category.Find(categoryID);
            _context.Category.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        }
    }

   
