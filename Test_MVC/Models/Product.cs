using System.ComponentModel.DataAnnotations.Schema;

namespace Test_MVC.Models
{
    public class Product
    {
        /// <summary>
        /// Code first necessary
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Product is sold in one or no shop
        /// </summary>
        public virtual Shop? Shop { get; set; } 

        /// <summary>
        /// URL address of photo which will be shown on page
        /// </summary>
        public string PhotoURL { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
