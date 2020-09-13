using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wooliesx_prizk.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public IList<Product> Products { get; set; }

    }
}
