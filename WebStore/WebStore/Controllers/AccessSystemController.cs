using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Services;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class AccessSystemController : Controller
    {
        private readonly PeopleService _peopleService;

        public AccessSystemController(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessSystem(string user, string password)
        {
            People people = _peopleService.GetPeopleByUserKey(user, password);

            return RedirectToAction("Index", "Home", new { cpf = people._cpf });
        }
    }
}
