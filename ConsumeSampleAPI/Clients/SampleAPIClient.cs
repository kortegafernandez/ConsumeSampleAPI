using ConsumeSampleAPI.Resource;
using System.Text.Json;

namespace ConsumeSampleAPI.Clients
{
    public class SampleAPIClient: ISampleAPIClient
    {
        private readonly HttpClient _client;

        public SampleAPIClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<string>> GetUniqueTopicsAsync() {
            var unicTopics = Enumerable.Empty<string>();
            
            var response = await _client.GetAsync("codingresources/codingResources");

            if (!response.IsSuccessStatusCode)
            {
                return unicTopics;
            }

            var resources = await JsonSerializer.DeserializeAsync<List<ResourceInformation>>(response.Content.ReadAsStream());

            unicTopics = resources?.SelectMany(r => r.topics).Distinct().ToList() ?? Enumerable.Empty<string>();

            return unicTopics;
        }
    }
}
