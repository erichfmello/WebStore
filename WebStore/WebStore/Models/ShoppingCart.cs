using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class ShoppingCart
    {
        [ForeignKey("People")]
        public string _cpf { get; private set; }
        [ForeignKey("Product")]
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
