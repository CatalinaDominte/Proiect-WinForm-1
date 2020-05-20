using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public  class Products
    {
       public int Id { get; set; }
        public string Name { get; set; }
    public decimal Price { get; set; }
    public int UnitsInStock { get; set; }
        public string ProductsDescription { get; set; }
        public int CategoryId { get; set; }

    }
}
