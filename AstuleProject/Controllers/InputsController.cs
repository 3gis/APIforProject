using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using GrupinisProjektas;
using GrupinisProjektas.Models;
using Newtonsoft.Json;

namespace GrupinisProjektas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputsController : ControllerBase
    {
        private IConfiguration _configuration;
        private IServiceProvider _serviceProvider;
        private readonly ILogger<InputsController> log;
        private readonly ILoggerFactory loggerSet;
        public InputsController(ILoggerFactory logger, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            loggerSet = logger;
            log = logger.CreateLogger<InputsController>();
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }



        [HttpGet]
        [Route("/_api/health")]
        [Produces("application/json")]
        public IActionResult Get()
        {
            log.LogDebug("Welcome to AzureAutomation.");
            return StatusCode(StatusCodes.Status200OK, "Ok.");
        }

        [HttpGet]
        [Route("/api/v1/project")]
        [Produces("application/json")]
        public IActionResult GetHanning()
        {

            log.LogDebug("Welcome to AzureAutomation.");
            return StatusCode(StatusCodes.Status200OK, "Ok.");
        }

        [HttpPost]
        [Route("/api/v1/project")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Creates repository in Azure", Description = "Does hanning for an array")]
        public async Task<string> Create(Masyvas request) //REQUEST = GENERIC IN SENTIL
        {
            double [] hanning = await new Worker().RunArray(request);
            //hanning.ToString();
            string json2 = JsonConvert.SerializeObject(hanning);
            return json2;
        }


        [HttpPost]
        [Route("/api/v1/reverse")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Reverse", Description = "Reverses signal array")]
        public async Task<string> Reverse(Reverse request) //REQUEST = GENERIC IN SENTIL
        {
            double[] hanning = await new Worker().RunReverse(request);
            string json2 = JsonConvert.SerializeObject(hanning);
            return json2;
        }

        [HttpPost]
        [Route("/api/v1/split")]
        [Produces("application/json")]
        [SwaggerOperation(Summary = "Reverse", Description = "Reverses signal array")]
        public async Task<Amongus> Split(Masyvas request) //REQUEST = GENERIC IN SENTIL
        {
            var amongus = new Worker().SplitChannels(request);

            return amongus;


        }

        //[HttpPost]
        //[Route("/api/v1/repository")]
        //[Produces("application/json")]
        //[SwaggerOperation(Summary = "Creates repository in Azure", Description = "Creates repository in Azure")]
        //public async Task<IActionResult> Post(GenericInputModel generic)
        //{
        //    await new Worker().RunAsync(generic);

        //    return StatusCode(StatusCodes.Status200OK, "Repo Created Succesfully");

        //}


        //[HttpDelete]
        //[Route("/api/v1/delete")]
        //[Produces("application/json")]
        //[SwaggerOperation(Summary = "Deletes repository/project in Azure", Description = "Deletes repository/project in Azure")]
        //public async Task<IActionResult> Delete(GenericInputModel generic)
        //{
        //    await new Worker().RunAsync(generic);

        //    return StatusCode(StatusCodes.Status200OK, "The Deletion was successfull");

        //}


    }
}
