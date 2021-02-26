using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Services
{
    public class ShoppingCartService
    {
        private readonly WebStoreContext _context;

        public ShoppingCartService(WebStoreContext context)
        {
            _context = context;
        }

        public List<ShoppingCart> GetShoppingCarts(string cpf)
        {
            return _context.ShoppingCart.Where(obj => obj._cpf == cpf).Include(obj => obj.Product).ToList();
        }

        public ShoppingCart GetShoppingCarts(string cpf, int idProduct)
        {
            return _context.ShoppingCart.Where(obj => obj._cpf == cpf && obj._idProduct == idProduct).Include(obj => obj.Product).ToList()[0];
        }


        public bool PostShoppingCart(ShoppingCart shoppingCart)
        {
            try
            {
                _context.ShoppingCart.Add(shoppingCart);
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool PutShoppingCart(ShoppingCart shoppingCart)
        {
            try
            {
                _context.ShoppingCart.Update(shoppingCart);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteShoppingCart(ShoppingCart shoppingCart)
        {
            try
            {
                _context.ShoppingCart.Remove(shoppingCart);
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
