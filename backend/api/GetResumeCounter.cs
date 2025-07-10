using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.CosmosDB;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Configuration;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        // Updated to test GitHub Actions workflow - Testing SERVICE_PRINCIPAL auth
        [FunctionName("GetResumeCounter")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"AzureResume", containerName: "Counter", Connection = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] Counter counter,
            [CosmosDB(databaseName:"AzureResume", containerName: "Counter", Connection = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] IAsyncCollector<Counter> updatedCounterCollector,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Handle case where counter document doesn't exist
            if (counter == null)
            {
                log.LogWarning("Counter document not found, creating new one");
                counter = new Counter
                {
                    Id = "1",
                    Count = 0
                };
            }

            counter.Count += 1;
            await updatedCounterCollector.AddAsync(counter);

            var jsonToReturn = JsonConvert.SerializeObject(counter);
            log.LogInformation($"Returning counter value: {counter.Count}");
            return new OkObjectResult(jsonToReturn);
        }
    }
}
