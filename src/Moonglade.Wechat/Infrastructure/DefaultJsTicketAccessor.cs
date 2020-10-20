using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moonglade.Wechat.Infrastructure.Cache;
using Moonglade.Wechat.Infrastructure.Result;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Moonglade.Wechat.Infrastructure
{
    public class DefaultJsTicketAccessor : IJsTicketAccessor
    {
        private readonly HttpClient _client;
        private readonly IAccessTokenAccessor _accessTokenAccessor;
        private readonly WechatSettings _options;
        private readonly IMemoryCache _cache;

        public DefaultJsTicketAccessor(IHttpClientFactory httpClientFactory,
            IAccessTokenAccessor accessTokenAccessor,
            IOptions<WechatSettings> options,
            IMemoryCache cache)
        {
            _client = httpClientFactory.CreateClient(WeChatConsts.HttpClientName);
            _accessTokenAccessor = accessTokenAccessor;
            _options = options.Value;
            _cache = cache;
        }

        public async Task<string> GetTicketAsync()
        {
            var key = JsTicketCacheItem.CalculateCacheKey(_options.AppId);
            var cacheItem = await _cache.GetOrCreateAsync(key, async cacheEntry =>
            {
                var accessToken = await _accessTokenAccessor.GetAccessTokenAsync();
                var requestUrl = $"/cgi-bin/ticket/getticket?access_token={accessToken}&type=jsapi";
                var result = await _client.GetStringAsync(requestUrl);
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var ticketResult = JsonSerializer.Deserialize<TicketResult>(result, jsonOptions); ;
                if (ticketResult.ErrorCode == WeChatReturnCode.Ok)
                {
                    cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(ticketResult.ExpiresIn);
                    return new JsTicketCacheItem(ticketResult.Ticket);
                }
                else
                {
                    throw new Exception(ticketResult.ToString());
                }
            });
            return cacheItem.Ticket;
        }
    }
}
