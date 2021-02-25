using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Services;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleService _peopleService;

        public PeopleController(PeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string _cpf, string name, string email, int ddi, int ddd, int celphoneNumber, int cep, string address,
            int number, string complement, string neighborhood, string city, string state, string accessType, string user, string password)
        {
            accessType = "CLI";
            People people = new People(_cpf, name, email, ddi, ddd, celphoneNumber, cep, address, number, complement, neighborhood, city, state, accessType, user, password);

            bool awnser = _peopleService.PostPeople(people);
            if (awnser)
            {
                return RedirectToAction("Index", "Home", new { cpf = people._cpf });
            }
            else
            {
                return BadRequest(awnser);
            }
        }
    }
}
