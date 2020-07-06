using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionDISample
{
    public class Greeting
    {
        private readonly IGreetingCreator _greetingCreator;
        public Greeting(IGreetingCreator greetingCreator)
        {
            _greetingCreator = greetingCreator;
        }

        [FunctionName("Greeting")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] 
            HttpRequest req, 
            ILogger log)
        {
            string name = req.Query["name"];
            Int32.TryParse(req.Query["hour"], out int hourOfDay);
            name = name ?? "Unknown";
            
            return new OkObjectResult($"{await _greetingCreator.CreateGreeting(hourOfDay)}, {name}!");
        }
    }
}