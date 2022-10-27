using AppService.Core.Interfaces.Services;
using AppService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppService.Api.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IAppService _appService;
        public AppController(IAppService appService)
        {
            _appService = appService?? throw new ArgumentNullException(nameof(appService));
                
        }
        /// <summary>
        ///  Get All Apps
        /// </summary>
        /// <returns>Apps</returns>
        [HttpGet]
        [Route("Apps")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<App>>> GetAppsAsync()
        {
            var res=await _appService.GetAllAppsAsync().ConfigureAwait(false);
            if (res == null) return NoContent();
             
            return Ok(res);
        }


    }
}
