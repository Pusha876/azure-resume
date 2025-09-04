using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Company.Function.Models
{
    public class GetResumeCounterOutputs
    {
        [CosmosDBOutput(
            databaseName: "AzureResume",
            containerName: "Counter",
            Connection = "AzureResumeConnectionString")]
        public Counter? Counter { get; set; }

        public HttpResponseData? HttpResponse { get; set; }
    }
}