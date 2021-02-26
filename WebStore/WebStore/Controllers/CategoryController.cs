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
    public class CategoryController : Controller
    {
        private readonly PeopleService _peopleService;
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public CategoryController(PeopleService peopleService, ProductService productService, CategoryService categoryService)
        {
            _peopleService = peopleService;
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Create(string cpf)
        {
            People people = _peopleService.GetPeopleByCpf(cpf);

            ProductCategoryVM productCategoryVM = new ProductCategoryVM();
            productCategoryVM.people = people;
            productCategoryVM.Categories.Add(new Category());

            return View(productCategoryVM);
        }

        [HttpPost]
        public IActionResult Create(string cpf, string Name)
        {
            Category category = new Category(Name);
            bool anwser = _categoryService.PostCategory(category);
            if (anwser)
            {
                return RedirectToAction("Create", "Product", new { cpf = cpf });
            }
            else
            {
                return BadRequest(anwser);
            }
        }
    }
}
