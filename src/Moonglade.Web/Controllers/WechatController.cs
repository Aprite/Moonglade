using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moonglade.Wechat;
using System;
using System.Threading.Tasks;

namespace Moonglade.Web.Controllers
{
    [Route("wechat")]
    public class WechatController : Controller
    {
        private readonly IJsSdkService _jsSdkService;
        private readonly ILogger<WechatController> _logger;
        public WechatController(
            ILogger<WechatController> logger,
            IJsSdkService jsSdkService)
        {
            _jsSdkService = jsSdkService;
            _logger = logger;
        }

        [HttpGet("js-sdk-config"), IgnoreAntiforgeryToken]
        public async Task<IActionResult> GetJsSdkConfigParameters([FromQuery] string jsUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(jsUrl))
                {
                    _logger.LogError("url is null.");
                    return BadRequest();
                }

                var config = await _jsSdkService.GetJsSdkUiPackageAsync(jsUrl);

                _logger.LogInformation($"JsSdkConfig:'{config}'.");

                return Json(config);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error uploading image.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
