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

        public IActionResult CreateUserMaster(string cpf)
        {
            ProductCategoryVM productCategoryVM = new ProductCategoryVM();
            People people = _peopleService.GetPeopleByCpf(cpf);
            productCategoryVM.people = people;

            return View(productCategoryVM);
        }

        [HttpPost]
        public IActionResult CreateUserMaster(string _cpf, string name, string email, int ddi, int ddd, int celphoneNumber, int cep, string address,
            int number, string complement, string neighborhood, string city, string state, string accessType, string oldCpf)
        {
            string user = name;
            string password = "123456789";

            People people = new People(_cpf, name, email, ddi, ddd, celphoneNumber, cep, address, number, complement, neighborhood, city, state,
                accessType, user, password);

            bool awnser = _peopleService.PostPeople(people);
            if (awnser)
            {
                return RedirectToAction("Index", "Home", new { cpf = oldCpf});
            }
            else
            {
                return BadRequest(awnser);
            }
        }
        public IActionResult Edit(string _cpf)
        {
            People people = _peopleService.GetPeopleByCpf(_cpf);
            ProductCategoryVM productCategoryVM = new ProductCategoryVM();
            productCategoryVM.people = people;

            return View(productCategoryVM);
        }

        [HttpPost]
        public IActionResult Edit(string _cpf, string name, string email, int ddi, int ddd, int celphoneNumber, int cep, string address,
            int number, string complement, string neighborhood, string city, string state, string user, string password)
        {
            People people = _peopleService.GetPeopleByCpf(_cpf);
            people.Name = name;
            people.Email = email;
            people.Ddi = ddi;
            people.Ddd = ddd;
            people.CelphoneNumber = celphoneNumber;
            people.Cep = cep;
            people.Address = address;
            people.Number = number;
            people.Complement = complement;
            people.Neighborhood = neighborhood;
            people.City = city;
            people.State = state;
            people.User = user;

            if (password != null)
            {
                people.Password = password;
            }

            bool awnser = _peopleService.PutPeople(people);
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
