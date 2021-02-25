using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class People
    {
        [Key]
        public string _cpf { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Ddi { get; set; }
        public int Ddd { get; set; }
        public int CelphoneNumber { get; set; }
        public int Cep { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AccessType { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public People()
        {
        }

        public People(string cpf, string name, string email, int ddi, int ddd, int celphoneNumber, int cep, string address, 
            int number, string neighborhood, string city, string state, string accessType, string user, string password)
        {
            _cpf = cpf;
            Name = name;
            Email = email;
            Ddi = ddi;
            Ddd = ddd;
            CelphoneNumber = celphoneNumber;
            Cep = cep;
            Address = address;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            AccessType = accessType;
            User = user;
            Password = password;
        }

        public People(string cpf, string name, string email, int ddi, int ddd, int celphoneNumber, int cep, string address, 
            int number, string complement, string neighborhood, string city, string state, string accessType, string user, string password)
        {
            _cpf = cpf;
            Name = name;
            Email = email;
            Ddi = ddi;
            Ddd = ddd;
            CelphoneNumber = celphoneNumber;
            Cep = cep;
            Address = address;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            AccessType = accessType;
            User = user;
            Password = password;
        }
    }
}
