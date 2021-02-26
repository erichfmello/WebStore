using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text.Json.Serialization;

namespace WebStore.Models
{
    public class Product
    {
        [Key]
        public int _idProduct { get; private set; }
        public string Description { get; set; }
        [Display(Name = "Nome do produto")]
        public string Title { get; set; }
        [Display(Name = "Preço R$")]
        public double Price { get; set; }
        public byte[] Picture { get; set; }
        public string State { get; set; }

        [ForeignKey("Category")]
        public int _idCategory { get; set; }

        public Category Category { get; set; }

        public Product()
        {
        }

        public Product(string description, string title, double price, string state)
        {
            Description = description;
            Title = title;
            Price = price;
            State = state;
        }

        public Product(string description, string title, double price, byte[] picture, string state, int idCategory, Category category)
        {
            Description = description;
            Title = title;
            Price = price;
            Picture = picture;
            State = state;
            _idCategory = idCategory;
            Category = category;
        }

        public Product(int idProduct, string description, string title, double price, byte[] picture, string state, int idCategory, Category category)
        {
            _idProduct = idProduct;
            Description = description;
            Title = title;
            Price = price;
            Picture = picture;
            State = state;
            _idCategory = idCategory;
            Category = category;
        }
    }
}
