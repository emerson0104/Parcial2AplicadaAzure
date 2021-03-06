﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;
using Parcial2Azure.Models;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;


namespace Parcial2Azure
{
    class CovidFAQ
    {
        [FunctionName("covidFAQ")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        [CosmosDB(
            databaseName:"Cosmodb",
            collectionName:"CosmodbConteiner",
            ConnectionStringSetting = "DBConnectionString"
            )] IEnumerable<FAQ> questionSet,
        ILogger log)
        {
            log.LogInformation("CosmodbConteiner");
            return new OkObjectResult(questionSet);
        }
    }
}
