using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wooliesx_prizk.Models
{
    public class E3Data
    {
        public IList<Product> Products { get; set; }
        public IList<Product> Quantities { get; set; }
        public IList<Special> Specials { get; set; }

    }

    public class Special
    {
        public IList<Product> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}
