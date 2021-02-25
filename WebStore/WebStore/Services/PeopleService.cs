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

        public People GetPeopleByUserKey(string user, string key)
        {
            return _context.People.FirstOrDefault(obj => obj.User == user && obj.Password == key);
        }
    }
}
