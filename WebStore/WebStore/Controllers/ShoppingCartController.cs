using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
using WebStore.Models.ViewModel;
using WebStore.Services;

namespace WebStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _shoppingCartService;
        private readonly PeopleService _peopleService;

        public ShoppingCartController(ShoppingCartService shoppingCartService, PeopleService peopleService)
        {
            _shoppingCartService = shoppingCartService;
            _peopleService = peopleService;
        }

        public IActionResult Edit(string cpf)
        {
            People people = _peopleService.GetPeopleByCpf(cpf);
            List<ShoppingCart> shoppingCarts = _shoppingCartService.GetShoppingCarts(cpf);

            ProductCategoryVM productCategoryVM = new ProductCategoryVM();
            productCategoryVM.people = people;
            productCategoryVM.ShoppingCarts = shoppingCarts;

            return View(productCategoryVM);
        }

        public IActionResult BuyEdit(string cpf, int idProduct)
        {
            People people = _peopleService.GetPeopleByCpf(cpf);
            ShoppingCart shoppingCart = _shoppingCartService.GetShoppingCarts(cpf, idProduct);

            ProductCategoryVM productCategoryVM = new ProductCategoryVM();
            productCategoryVM.people = people;
            productCategoryVM.ShoppingCarts.Add(shoppingCart);
            productCategoryVM.Description = shoppingCart.Product.Description;
            productCategoryVM.Title = shoppingCart.Product.Title;
            productCategoryVM.Amount = shoppingCart.Amount;

            return View(productCategoryVM);
        }

        [HttpPost]
        public IActionResult BuyEdit(string cpf, int idProduct, int amount)
        {
            People people = _peopleService.GetPeopleByCpf(cpf);
            ShoppingCart shoppingCart = _shoppingCartService.GetShoppingCarts(cpf, idProduct);

            shoppingCart.Amount = amount;

            bool anwser = _shoppingCartService.PutShoppingCart(shoppingCart);
            if (anwser)
            {
                return RedirectToAction("Edit", "ShoppingCart", new { cpf = cpf });
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPost]
        public IActionResult AddToShoppingCart(string cpf, int idProduct, int amount)
        {
            ShoppingCart shoppingCart = new ShoppingCart(cpf, idProduct, amount);

            bool anwser = _shoppingCartService.PostShoppingCart(shoppingCart);
            if (anwser)
            {
                return RedirectToAction("Index", "Home", new { cpf = cpf });
            }
            else
            {
                return BadRequest(false);
            }
        }


        public IActionResult Delete(string cpf, int idProduct)
        {
            ShoppingCart shoppingCart = _shoppingCartService.GetShoppingCarts(cpf, idProduct);

            bool anwser = _shoppingCartService.DeleteShoppingCart(shoppingCart);
            if (anwser)
            {
                return RedirectToAction("Edit", "ShoppingCart", new { cpf = cpf });
            }
            else
            {
                return BadRequest(false);
            }
        }
    }
}
