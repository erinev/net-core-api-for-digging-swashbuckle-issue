using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdRelations.Reader.Host.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/adrelations/ads")]
    [Produces("application/json")]
    public class AdRelationsController : ControllerBase
    {
        /// <summary>
        /// Retrieves parent ad relations
        /// </summary>
        /// <returns>List of parent ad relations</returns>
        [HttpGet("parentads")]
        [ProducesResponseType(typeof(List<Guid>), StatusCodes.Status200OK)]
        public IActionResult GetByAdUuid()
        {
            List<Guid> parentAds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };

            return Ok(parentAds);
        }
    }
}
