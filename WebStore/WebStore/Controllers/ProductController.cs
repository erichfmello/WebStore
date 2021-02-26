using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Services;
using WebStore.Models;
using WebStore.Models.ViewModel;

namespace WebStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly PeopleService _peopleService;
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public ProductController(PeopleService peopleService, ProductService productService, CategoryService categoryService)
        {
            _peopleService = peopleService;
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index(string cpf)
        {
            People people = _peopleService.GetPeopleByCpf(cpf);
            List<Product> product = _productService.GetProducts();

            ProductCategoryVM productCategoryVM = new ProductCategoryVM();
            productCategoryVM.people = people;
            productCategoryVM.Products = product;

            return View(productCategoryVM);
        }

        public IActionResult Create(string cpf)
        {
            People people = _peopleService.GetPeopleByCpf(cpf);

            ProductCategoryVM productCategoryVM = new ProductCategoryVM();
            productCategoryVM.people = people;
            productCategoryVM.Categories = _categoryService.GetCategories();
            productCategoryVM.Products.Add(new Product());

            return View(productCategoryVM);
        }

        [HttpPost]
        public IActionResult Create(string cpf, string description, string title, double price, string state, int id)
        {
            Product product = new Product(description, title, price, state);
            product._idCategory = id;

            bool anwser = _productService.PostProduct(product);
            if (anwser)
            {
                return RedirectToAction("Index", "Product", new { cpf = cpf });
            }
            else
            {
                return BadRequest(false);
            }
        }

        public IActionResult Edit(string cpf, int idProduct)
        {
            People people = _peopleService.GetPeopleByCpf(cpf);
            Product product = _productService.GetProductsById(idProduct);

            ProductCategoryVM productCategoryVM = new ProductCategoryVM();
            productCategoryVM.people = people;
            productCategoryVM.Categories = _categoryService.GetCategories();
            productCategoryVM.Products.Add(product);

            productCategoryVM.Description = product.Description;
            productCategoryVM.Title = product.Title;
            productCategoryVM.Price = product.Price;
            productCategoryVM.State = product.State;
            productCategoryVM.Id = product._idCategory;
            productCategoryVM.IdProduct = product._idProduct;

            return View(productCategoryVM);
        }

        [HttpPost]
        public IActionResult Edit(string cpf, string description, string title, double price, string state, int id, int idProduct)
        {
            Product product = _productService.GetProductsById(idProduct);
            product.Description = description;
            product.Title = title;
            product.Price = price;
            product.State = state;
            product._idCategory = id;

            bool anwser = _productService.PutProduct(product);
            if (anwser)
            {
                return RedirectToAction("Index", "Product", new { cpf = cpf });
            }
            else
            {
                return BadRequest(false);
            }
        }

        public IActionResult Delete(string cpf, int idProduct)
        {
            Product product = _productService.GetProductsById(idProduct);

            bool anwser = _productService.DeleteProduct(product);
            if (anwser)
            {
                return RedirectToAction("Index", "Product", new { cpf = cpf });
            }
            else
            {
                return BadRequest(false);
            }
        }

        public IActionResult Buy(string cpf, int idProduct)
        {
            People people = _peopleService.GetPeopleByCpf(cpf);
            Product product = _productService.GetProductsById(idProduct);

            ProductCategoryVM productCategoryVM = new ProductCategoryVM();
            productCategoryVM.people = people;

            productCategoryVM.Description = product.Description;
            productCategoryVM.Title = product.Title;
            productCategoryVM.IdProduct = product._idProduct;

            return View(productCategoryVM);
        }
    }
}
