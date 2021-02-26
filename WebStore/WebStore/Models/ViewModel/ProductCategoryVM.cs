using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models.ViewModel
{
    public class ProductCategoryVM
    {
        public People people { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

        public string Name { get; set; }

        public string Description { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string State { get; set; }
        public int Id { get; set; }
        public int IdProduct { get; set; }

        [Display(Name = "Quantidade")]
        public int Amount { get; set; }

        public ProductCategoryVM()
        {
        }
    }
}
