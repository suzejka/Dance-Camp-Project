using System.ComponentModel.DataAnnotations;

namespace Test_MVC.Models
{
    public class Shop
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Uzupełnij pole!")]
        public string Name { get ; set;}
        //[Required(ErrorMessage = "Uzupełnij pole!")]
        public string Description { get; set; }


        /// <summary>
        /// Shop sells many products
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        public Shop()
        {
            Products = new HashSet<Product>();
        }
    }
}
