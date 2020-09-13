using System;
using System.Linq;
using System.Threading.Tasks;
using wooliesx_prizk.Models;
using wooliesx_prizk.Providers;

namespace wooliesx_prizk.Core
{
    public interface ISortStrategyJunction
    {
        public Task<ISortStrategy> Get(SortOptions which);
    }

    public class SortStrategyJunction : ISortStrategyJunction
    {
        private readonly EndpointProvider endpointProvider;

        public SortStrategyJunction(EndpointProvider endpointProvider)
        {
            this.endpointProvider = endpointProvider;
        }

        public async Task<ISortStrategy> Get(SortOptions which)
        {
            return which switch
            {
                SortOptions.Low => new SortStrategyLow(await endpointProvider.GetProducts()),
                SortOptions.High => new SortStrategyHigh(await endpointProvider.GetProducts()),
                SortOptions.Ascending => new SortStrategyAscending(await endpointProvider.GetProducts()),
                SortOptions.Descending => new SortStrategyDescending(await endpointProvider.GetProducts()),
                SortOptions.Recommended => new SortStrategyRecommended(await endpointProvider.GetPurchases()),
                _ => throw new ArgumentException($"bad type {which}")
            };
        }
    }





}
