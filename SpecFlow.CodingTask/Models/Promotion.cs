 
using System.Collections.Generic; 

namespace SpecFlow.CodingTask.Models
{
    public class Promotion
    {
        public List<Product> Products { get; set; }
        public Product DiscountedProduct { get; set; }
        public double Percentage { get; set; }
    }
}
