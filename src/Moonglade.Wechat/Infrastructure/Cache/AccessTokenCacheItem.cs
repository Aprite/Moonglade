using System;
using System.Collections.Generic;
using System.Text;

namespace Moonglade.Wechat.Infrastructure.Cache
{
    public class AccessTokenCacheItem
    {
        public string AccessToken { get; set; }

        public AccessTokenCacheItem(string accessToken)
        {
            AccessToken = accessToken;
        }

        public static string CalculateCacheKey(string appId)
        {
            return "wechat:accesstoken:id:" + appId;
        }
    }
}
