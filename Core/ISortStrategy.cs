using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wooliesx_prizk.Models;

namespace wooliesx_prizk.Core
{
    public interface ISortStrategy
    {
        Task<IOrderedEnumerable<Product>> Sort();
    }
}
