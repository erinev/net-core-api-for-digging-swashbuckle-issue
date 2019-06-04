using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Demo.Api.Host.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/demo")]
    [Produces("application/json")]
    public class DemoController : ControllerBase
    {
        private readonly IApiDescriptionGroupCollectionProvider _apiDescriptionGroupCollection;

        public DemoController(IApiDescriptionGroupCollectionProvider apiDescriptionGroupCollection)
        {
            _apiDescriptionGroupCollection = apiDescriptionGroupCollection;
        }

        [HttpGet("resource")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult GetResource()
        {
            foreach (var apiDescriptionGroupItem in _apiDescriptionGroupCollection.ApiDescriptionGroups.Items)
            {
                foreach (var apiDescriptionItem in apiDescriptionGroupItem.Items)
                {
                    Console.WriteLine($"------------------------------------------------------------------");
                    Console.WriteLine($"apiDescriptionItem.GroupName: {apiDescriptionItem.GroupName}");
                    Console.WriteLine($"apiDescriptionItem.HttpMethod: {apiDescriptionItem.HttpMethod}");
                    Console.WriteLine($"apiDescriptionItem.RelativePath: {apiDescriptionItem.RelativePath}");
                    Console.WriteLine($"------------------------------------------------------------------");
                }
            }

            return Ok("resource");
        }
    }
}
