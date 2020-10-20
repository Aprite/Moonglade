using System;
using System.Text.Json.Serialization;

namespace Moonglade.Wechat.Infrastructure.Result
{
    /// <summary>
    /// 获取access_token
    /// </summary>
    [Serializable]
    public class AccessTokenResult : WeChatJsonResult
    {
        /// <summary>
        /// 接口调用凭证
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// access_token接口调用凭证超时时间，单位（秒）
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
