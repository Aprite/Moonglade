using Microsoft.Extensions.Options;
using Moonglade.Wechat.Common.Extensions;
using Moonglade.Wechat.Common.Signature;
using Moonglade.Wechat.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Moonglade.Wechat
{
    public class JsSdkService : IJsSdkService
    {
        private readonly IJsTicketAccessor _jsTicketAccessor;
        private readonly HttpClient _client;
        private readonly ISignatureGenerator _signatureGenerator;
        private readonly WechatSettings _options;

        public JsSdkService(
            IJsTicketAccessor jsTicketAccessor,
            IHttpClientFactory httpClientFactory,
            ISignatureGenerator signatureGenerator,
            IOptions<WechatSettings> options)
        {
            _jsTicketAccessor = jsTicketAccessor;
            _client = httpClientFactory.CreateClient(WeChatConsts.HttpClientName);
            _signatureGenerator = signatureGenerator;
            _options = options.Value;
        }

        public async Task<JsSdkConfigParameters> GetJsSdkUiPackageAsync(string url)
        {
            var nonceStr = RandomStringHelper.GetRandomString();
            var timeStamp = DateTimeHelper.GetNowTimeStamp();
            var ticket = await _jsTicketAccessor.GetTicketAsync();

            var @params = new WeChatParameters();
            @params.AddParameter("noncestr", nonceStr);
            @params.AddParameter("jsapi_ticket", ticket);
            @params.AddParameter("url", url);// HttpUtility.UrlDecode(jsUrl));
            @params.AddParameter("timestamp", timeStamp);

            var signStr = _signatureGenerator.Generate(@params, SHA1.Create()).ToLower();

            return new JsSdkConfigParameters(_options.AppId, timeStamp, nonceStr, signStr);
        }
    }
}
