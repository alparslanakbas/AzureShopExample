using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureShop.Cart.Function;

public class ProductFunctions(ILogger<ProductFunctions> logger)
{
    [Function(nameof(ProductAdded))]
    [ServiceBusOutput("product-processed", Connection = "ServiceBus")]
    public string ProductAdded([ServiceBusTrigger("product-added", Connection = "ServiceBus")] 
            ServiceBusReceivedMessage message)
    {
        logger.LogInformation("Message ID: {id}", message.MessageId);
        logger.LogInformation("Message Body: {body}", message.Body);
        logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

        using var reader = new StreamReader(message.Body.ToStream());
        return reader.ReadToEnd();
    }
}
