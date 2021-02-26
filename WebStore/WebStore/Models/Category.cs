using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class Category
    {
        [Key]
        public int _idCategory { get; private set; }
        [Display(Name = "Categoria")]
        public string Name { get; set; }

        public List<Product> Products { get; set; }

        public Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }
    }
}
