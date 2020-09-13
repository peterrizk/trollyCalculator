using EnsureThat;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wooliesx_prizk.Models;

namespace wooliesx_prizk.Core
{
    public class SortStrategyAscending : ISortStrategy
    {
        private readonly IEnumerable<Product> source;

        public SortStrategyAscending(IEnumerable<Product> source)
        {
            this.source = source;
        }

        public Task<IOrderedEnumerable<Product>> Sort()
        {
            EnsureArg.IsNotNull(source);

            return Task.FromResult(source.OrderBy(p => p.Name));

        }
    }
}
