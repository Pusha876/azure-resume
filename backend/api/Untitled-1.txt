// filepath: c:\WORKSPACE\azure-resume\backend\api\GetResumeCounter.cs
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Extensions.CosmosDB;
using Newtonsoft.Json;

namespace Company.Function
{
    public class GetResumeCounter
    {
        private readonly ILogger _logger;

        public GetResumeCounter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetResumeCounter>();
        }

        [Function("GetResumeCounter")]
        [CosmosDBOutput(databaseName: "AzureResume", containerName: "Counter", Connection = "AzureResumeConnectionString")]
        public async Task<MultipleOutputBinding> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            [CosmosDBInput(databaseName: "AzureResume", containerName: "Counter", Connection = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] Counter counter)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Handle case where counter document doesn't exist
            if (counter == null)
            {
                counter = new Counter
                {
                    Id = "1",
                    Count = 0
                };
            }

            // Increment the counter
            counter.Count += 1;

            // Create HTTP response
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");

            var jsonToReturn = JsonConvert.SerializeObject(counter);
            await response.WriteStringAsync(jsonToReturn);

            return new MultipleOutputBinding
            {
                HttpResponse = response,
                CosmosOutput = counter
            };
        }
    }

    public class MultipleOutputBinding
    {
        [CosmosDBOutput(databaseName: "AzureResume", containerName: "Counter", Connection = "AzureResumeConnectionString")]
        public Counter CosmosOutput { get; set; }

        public HttpResponseData HttpResponse { get; set; }
    }
}