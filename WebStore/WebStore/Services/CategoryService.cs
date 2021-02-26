using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Services
{
    public class CategoryService
    {
        private readonly WebStoreContext _context;

        public CategoryService(WebStoreContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Category.ToList();
        }

        public bool PostCategory(Category category)
        {
            try
            {
                _context.Category.Add(category);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}