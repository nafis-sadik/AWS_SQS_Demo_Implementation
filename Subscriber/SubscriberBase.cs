using Amazon.SQS;
using Amazon.SQS.Model;
using Models;
using System.Text.Json;

namespace Subscriber
{
    public class SubscriberBase : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IAmazonSQS _amazonSQS;
        private readonly HandlerFactory _handlerFactory;

        public SubscriberBase(IConfiguration configuration, IAmazonSQS amazonSQS, HandlerFactory handlerFactory)
        {
            _configuration = configuration;
            _amazonSQS = amazonSQS;
            _amazonSQS.GetQueueUrlAsync(_configuration["AWS:SQS:QueueUrl"]);
            _handlerFactory = handlerFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Background process started");

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Long Poling");
                var response = await _amazonSQS.ReceiveMessageAsync(new ReceiveMessageRequest
                {
                    QueueUrl = _configuration["AWS:SQS:QueueUrl"],
                    WaitTimeSeconds = 1
                });
                foreach(var message in response.Messages)
                {
                    var dataObj = JsonSerializer.Deserialize<BaseModel>(message.Body);

                    if (_handlerFactory.canHandle(dataObj))
                    {
                        await _handlerFactory.invokeHandler(dataObj.MessageTypeName, message.Body);

                        var msgTypeName = message.MessageAttributes.GetValueOrDefault("Route")?.StringValue;

                        if (string.IsNullOrEmpty(msgTypeName))
                            Console.WriteLine("No attributes found");
                        await _amazonSQS.DeleteMessageAsync(_configuration["AWS:SQS:QueueUrl"], message.ReceiptHandle, stoppingToken);
                    }
                    else
                    {
                        throw new ArgumentException($"Object {dataObj} is not a handeled type yet!");
                    }
                }
            }

            Console.WriteLine($"Exiting {nameof(SubscriberBase)} process");
        }
    }
}
