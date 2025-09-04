using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Company.Function.Models
{
    public class MultipleOutputBinding
    {
        [CosmosDBOutput(databaseName: "AzureResume", containerName: "Counter", Connection = "AzureResumeConnectionString")]
        public Counter CosmosOutput { get; set; }

        public HttpResponseData HttpResponse { get; set; }
    }
}