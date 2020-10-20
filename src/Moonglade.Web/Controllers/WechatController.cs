using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moonglade.Model.Settings;
using Moonglade.Wechat;
using System;
using System.Threading.Tasks;

namespace Moonglade.Web.Controllers
{
    [Route("wechat")]
    public class WechatController : BlogController
    {
        private readonly IJsSdkService _jsSdkService;
        public WechatController(
            ILogger<WechatController> logger,
            IOptions<AppSettings> settings,
            IJsSdkService jsSdkService) : base(logger, settings)
        {
            _jsSdkService = jsSdkService;
        }

        [HttpGet("js-sdk-config"), IgnoreAntiforgeryToken]
        public async Task<IActionResult> GetJsSdkConfigParameters([FromQuery] string jsUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(jsUrl))
                {
                    Logger.LogError("url is null.");
                    return BadRequest();
                }

                var config = await _jsSdkService.GetJsSdkUiPackageAsync(jsUrl);

                Logger.LogInformation($"JsSdkConfig:'{config}'.");

                return Json(config);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error uploading image.");
                return ServerError();
            }
        }
    }
}
