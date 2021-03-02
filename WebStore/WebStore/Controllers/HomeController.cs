using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
using WebStore.Models.ViewModel;
using WebStore.Services;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeSerice _homeSerice;
        private readonly PeopleService _peopleService;
        private readonly ProductService _productService;

        public HomeController(ILogger<HomeController> logger, HomeSerice homeSerice, PeopleService peopleService, ProductService productService)
        {
            _logger = logger;
            _homeSerice = homeSerice;
            _peopleService = peopleService;
            _productService = productService;
        }

        public IActionResult Index(string cpf)
        {
            
            People people;
            List<Product> products = _productService.GetProducts();

            ProductCategoryVM productCategoryVM = new ProductCategoryVM();

            if (cpf == null)
            {
                people = new People();
            }
            else
            {
                people = _homeSerice.getPeoploByCpf(cpf);
            }

            // people = _peopleService.GetPeopleByCpf("11122233377");
            productCategoryVM.people = people;
            productCategoryVM.Products = products;
            return View(productCategoryVM);
            // return RedirectToAction("Create", "People");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
