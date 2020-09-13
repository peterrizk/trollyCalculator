using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using wooliesx_prizk.Models;

namespace wooliesx_prizk.Providers
{
    public class EndpointProvider
    {
        private readonly HttpClient httpClient;

        public EndpointProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await Deserialize<Product>("/api/resource/products?token=27ccf471-4698-44bb-ac8d-5d0025687463");
        }

        public async Task<IEnumerable<Customer>> GetPurchases()
        {
            return await Deserialize<Customer>("/api/resource/shopperHistory?token=27ccf471-4698-44bb-ac8d-5d0025687463");
        }

        private async Task<IEnumerable<T>> Deserialize<T>(string endpoint)
        {
            var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
            using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken.Token))
            {
                var stream = await response.Content.ReadAsStreamAsync();

                if (response.IsSuccessStatusCode)
                    return DeserializeStream<IEnumerable<T>>(stream);
            }

            return new List<T>();
        }

        private T DeserializeStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var streamReader = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                var jsonSerializer = new JsonSerializer();
                var searchResult = jsonSerializer.Deserialize<T>(jsonTextReader);
                return searchResult;
            }
        }
    }
}
