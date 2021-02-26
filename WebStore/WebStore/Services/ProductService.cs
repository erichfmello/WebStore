using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Services
{
    public class ProductService
    {
        private readonly WebStoreContext _context;

        public ProductService(WebStoreContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            IQueryable<Product> iq = _context.Product;
            List<Product> list = iq.AsNoTracking().Include(obj => obj.Category).ToList();
            return list;
        }

        public Product GetProductsById(int id)
        {
            return _context.Product.FirstOrDefault(obj => obj._idProduct == id);
        }

        public bool PostProduct(Product product)
        {
            try
            {
                _context.Product.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PutProduct(Product product)
        {
            try
            {
                _context.Product.Update(product);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteProduct(Product product)
        {
            try
            {
                _context.Product.Remove(product);
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
