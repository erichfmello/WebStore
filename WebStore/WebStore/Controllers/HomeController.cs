using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
using WebStore.Services;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeSerice _homeSerice;

        public HomeController(ILogger<HomeController> logger, HomeSerice homeSerice)
        {
            _logger = logger;
            _homeSerice = homeSerice;
        }

        public IActionResult Index(string cpf)
        {
            People people;
            if (cpf == null)
            {
                people = new People();
            }
            else
            {
                people = _homeSerice.getPeoploByCpf(cpf);
            }
            return View(people);
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
