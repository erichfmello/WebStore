using System.Drawing;

namespace WebStore.Models
{
    public class Product
    {
        private Bitmap picture;

        public int _idProduct { get; private set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Bitmap Picture { get => picture; set => picture = value; }
        public string State { get; set; }
        public int _idCategory { get; set; }
        public Category Category { get; set; }

        public Product()
        {
        }

        public Product(Bitmap picture, int idProduct, string title, double price, string state)
        {
            this.picture = picture;
            _idProduct = idProduct;
            Title = title;
            Price = price;
            State = state;
        }

        public Product(int idProduct, string description, string title, double price, Bitmap picture, string state)
        {
            _idProduct = idProduct;
            Description = description;
            Title = title;
            Price = price;
            Picture = picture;
            State = state;
        }
    }
}
