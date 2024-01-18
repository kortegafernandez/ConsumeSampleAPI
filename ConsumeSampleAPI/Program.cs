using ConsumeSampleAPI.Clients;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddHttpClient<ISampleAPIClient, SampleAPIClient>()
    .ConfigureHttpClient((serviceProvider, httpClient) =>
    {
        httpClient.DefaultRequestHeaders.Accept.Clear();        
        httpClient.BaseAddress = new Uri("https://api.sampleapis.com/");
    }
    );

var serviceProvider = serviceCollection.BuildServiceProvider();

var client = serviceProvider.GetRequiredService<ISampleAPIClient>();
var response = await client.GetUniqueTopicsAsync();
response.ToList().ForEach(i => Console.WriteLine(i.ToString()));