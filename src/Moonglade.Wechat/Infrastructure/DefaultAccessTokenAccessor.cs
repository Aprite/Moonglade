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
    public class DefaultAccessTokenAccessor : IAccessTokenAccessor
    {
        private readonly IMemoryCache _cache;
        private readonly HttpClient _client;
        private readonly WechatSettings _options;

        public DefaultAccessTokenAccessor(IMemoryCache cache,
            IHttpClientFactory httpClientFactory,
            IOptions<WechatSettings> options)
        {
            _cache = cache;
            _client = httpClientFactory.CreateClient(WeChatConsts.HttpClientName);
            _options = options.Value;
        }

        public virtual async Task<string> GetAccessTokenAsync()
        {
            var key = AccessTokenCacheItem.CalculateCacheKey(_options.AppId);
            var cacheItem = await _cache.GetOrCreateAsync(key, async cacheEntry =>
            {
                var requestUrl = $"/cgi-bin/token?grant_type={GrantTypes.ClientCredential}&appid={_options.AppId}&secret={_options.AppSecret}";
                var result = await _client.GetStringAsync(requestUrl);
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var accessTokenResult = JsonSerializer.Deserialize<AccessTokenResult>(result, jsonOptions);
                if (accessTokenResult.ErrorCode == WeChatReturnCode.Ok)
                {
                    cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(accessTokenResult.ExpiresIn);
                    return new AccessTokenCacheItem(accessTokenResult.AccessToken);
                }
                else
                {
                    throw new Exception(accessTokenResult.ToString());
                }
            });
            return cacheItem.AccessToken;
        }
    }
}
