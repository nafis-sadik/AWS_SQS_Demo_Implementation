using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SQSController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> SendMsg(User data)
        {
            var creds = new BasicAWSCredentials(accessKey: "AKIA54WLFYVLLALDDON2", secretKey: "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");
            var client = new AmazonSQSClient(creds, Amazon.RegionEndpoint.EUWest1);
            data.MessageTypeName = nameof(User);
            var request = new SendMessageRequest
            {
                QueueUrl = "https://sqs.eu-west-1.amazonaws.com/954982581590/oslofjord-dev-queue",
                MessageBody = JsonSerializer.Serialize(data),
                DelaySeconds = 0
            };
            var reqMsg = await client.SendMessageAsync(request);
            return reqMsg.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
