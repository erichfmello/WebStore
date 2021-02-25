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
        [Display(Name ="CPF:")]
        public string _cpf { get; private set; }
        [Display(Name = "Nome:")]
        public string Name { get; set; }
        [Display(Name = "e-mail:")]
        public string Email { get; set; }
        [Display(Name = "DDI:")]
        public int Ddi { get; set; }
        [Display(Name = "DDD:")]
        public int Ddd { get; set; }
        [Display(Name = "Telefone:")]
        public int CelphoneNumber { get; set; }
        [Display(Name = "CEP")]
        public int Cep { get; set; }
        [Display(Name = "Rua:")]
        public string Address { get; set; }
        [Display(Name = "Número")]
        public int Number { get; set; }
        [Display(Name = "Complemento:")]
        public string Complement { get; set; }
        [Display(Name = "Bairro:")]
        public string Neighborhood { get; set; }
        [Display(Name = "Cidade:")]
        public string City { get; set; }
        [Display(Name = "UF:")]
        public string State { get; set; }
        public string AccessType { get; set; }
        [Display(Name = "Usuário")]
        public string User { get; set; }
        [Display(Name = "Senha:")]
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
