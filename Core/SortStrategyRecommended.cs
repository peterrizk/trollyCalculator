using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wooliesx_prizk.Models;

namespace wooliesx_prizk.Core
{
    public class SortStrategyRecommended : ISortStrategy
    {
        private readonly IEnumerable<Customer> source;
        private SortedList<string, Product> sortedList = new SortedList<string, Product>();

        public SortStrategyRecommended(IEnumerable<Customer> source)
        {
            this.source = source;
        }
        public Task<IOrderedEnumerable<Product>> Sort()
        {
            EnsureArg.IsNotNull(source);

            foreach (var item in GetProducts())
            {
                var key = NormalizeKey(item.Name);
                switch (sortedList.ContainsKey(key))
                {
                    case true:
                        var product = sortedList[key];
                        product.Quantity = product.Quantity + item.Quantity;
                        sortedList[key] = product;
                        break;
                    case false:
                        sortedList.Add(key, item);
                        break;
                    default: throw new Exception("unexpected occurance in recommended strategy");
                }
            }
            var results = sortedList.Values.OrderByDescending(i => i.Quantity);
            return Task.FromResult(results);
        }

        private string NormalizeKey(string key)
        {
            EnsureArg.IsNotNull(key);
            return key.ToLower();
        }

        private IEnumerable<Product> GetProducts()
        {
            foreach (var customer in source)
            {
                foreach (Product product in customer.Products)
                {
                    yield return product;
                }
            }
        }
    }
}
