using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Services
{
    public class HomeSerice
    {
        private readonly WebStoreContext _context;

        public HomeSerice(WebStoreContext context)
        {
            _context = context;
        }

        public People getPeoploByCpf(string cpf)
        {
            return _context.Peoples.FirstOrDefault(obj => obj._cpf == cpf);
        }
    }
}
