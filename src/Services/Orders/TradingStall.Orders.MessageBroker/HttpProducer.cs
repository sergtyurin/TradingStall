using Newtonsoft.Json;
using TradingStall.Orders.Application.NotificationHandler;

namespace TradingStall.Orders.MessageBroker;

public class HttpProducer
{
    //TODO: Store publishing uris in configuration
    private readonly List<Uri> publishingUris = new()
    {
        new Uri("http://localhost:5000/api/v1/Messaging")
    };
        
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpProducer(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task Publish(IntegrationEvent integrationEvent, CancellationToken cancellationToken)
    {
        var @event = "?event=" + JsonConvert.SerializeObject(integrationEvent);
        
        var httpClient = _httpClientFactory.CreateClient();

        foreach (var publishingUri in publishingUris)
        {
            httpClient.BaseAddress = publishingUri;
            await httpClient.GetAsync(@event, cancellationToken);
        }
    }
}
