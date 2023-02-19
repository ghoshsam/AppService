using AppService.Core.Interfaces.Services;
using AppService.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AppService.Api.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppsController : ControllerBase
    {
        private readonly IAppService _appService;
        public AppsController(IAppService appService)
        {
            ArgumentNullException.ThrowIfNull(appService, nameof(appService));
            _appService = appService;
            //_appService = appService?? throw new ArgumentNullException(nameof(appService));

        }
        /// <summary>
        ///  Get All Apps
        /// </summary>
        /// <returns>Apps</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<App>>> GetAppsAsync()
        {
            var res = await _appService.GetAllAppsAsync().ConfigureAwait(false);
            // if (res == null) return NoContent();
            return res == null ? NoContent() : Ok(res);
            //return Ok(res);
        }
        [Authorize]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {

            var res = await _appService.GetAllAppsAsync().ConfigureAwait(false);
            return Ok();
        }


    }
}
