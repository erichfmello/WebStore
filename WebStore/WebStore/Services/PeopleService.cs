using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Services
{
    public class PeopleService
    {
        private readonly WebStoreContext _context;

        public PeopleService(WebStoreContext context)
        {
            _context = context;
        }

        public People GetPeopleByCpf(string cpf)
        {
            return _context.People.FirstOrDefault(obj => obj._cpf == cpf);
        }

        public People GetPeopleByUserKey(string user, string key)
        {
            return _context.People.FirstOrDefault(obj => obj.User == user && obj.Password == key);
        }

        public bool PostPeople(People people)
        {
            try
            {
                _context.People.Add(people);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PutPeople(People people)
        {
            try
            {
                _context.People.Update(people);
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
