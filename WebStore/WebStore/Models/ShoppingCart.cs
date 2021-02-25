using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class ShoppingCart
    {
        [Key]
        public string _cpf { get; private set; }
        public int _idProduct { get; private set; }
        public int Amount { get; set; }

        public People People { get; set; }
        public Product Product { get; set; }

        public ShoppingCart()
        {
        }

        public ShoppingCart(string cpf, int idProduct, int amount)
        {
            _cpf = cpf;
            _idProduct = idProduct;
            Amount = amount;
        }
    }
}
