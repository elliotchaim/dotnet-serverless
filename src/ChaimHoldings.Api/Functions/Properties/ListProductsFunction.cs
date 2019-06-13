using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace ChaimHoldings.Api.Functions.Properties
{
    public static class ListPropertiesFunction
    {
        [FunctionName("ListProperties")]
        // TODO: filters for error handling, and logging
        public static async Task<IActionResult> Run
        (
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "properties.list")] HttpRequest request
        )
        {
            // todo: validate access token

            var properties = new[]
            {
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Modest Mansion in Manchester",
                    AskingPrice = 1200000M
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Cosy Cottage in Chesterfield",
                    AskingPrice = 345000M
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Name = "Run-down Ruins in Rotherham",
                    AskingPrice = 345000M
                }
            };

            return new OkObjectResult(properties);
        }
    }
}
