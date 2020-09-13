using EnsureThat;
using System;
using System.Linq;
using System.Threading.Tasks;
using wooliesx_prizk.Models;
using wooliesx_prizk.Providers;

namespace wooliesx_prizk.Core
{
    public interface ICalculator
    {
        public decimal Calculate(E3Data data);
    }

    public class SpecialsCaclulator : ICalculator
    {
        //TODO only consider special when they apply to items in the cart
        public decimal Calculate(E3Data data)
        {
            return  data.Specials.Min(s => s.Total);
        }
    }

    public class StandardCaclulator : ICalculator
    {
        //TODO only consider products that are not on special
        public decimal Calculate(E3Data data)
        {
            decimal total = 0;
            foreach(var line in data.Quantities)
            {
                var product = data.Products.FirstOrDefault(p => string.Compare(p.Name, line.Name, comparisonType: StringComparison.OrdinalIgnoreCase) == 0);
                if (product is null) continue;
                total = total + ( line.Quantity * product.Price);
            }
            return total;
        }
    }

}
