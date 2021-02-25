using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class Category
    {
        [Key]
        public int _idCategory { get; private set; }
        public string Name { get; set; }

        public Category()
        {
        }

        public Category(int idCategory, string name)
        {
            _idCategory = idCategory;
            Name = name;
        }
    }
}
