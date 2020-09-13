using EnsureThat;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wooliesx_prizk.Models;

namespace wooliesx_prizk.Core
{
    public class SortStrategyDescending : ISortStrategy
    {
        private readonly IEnumerable<Product> source;

        public SortStrategyDescending(IEnumerable<Product> source)
        {
            this.source = source;
        }

        public Task<IOrderedEnumerable<Product>> Sort()
        {
            EnsureArg.IsNotNull(source);

            return Task.FromResult(source.OrderByDescending(p => p.Name));

        }
    }
}
