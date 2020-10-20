using System.Text.Json.Serialization;

namespace Moonglade.Wechat.Infrastructure.Result
{
    public class TicketResult : WeChatJsonResult
    {
        /// <summary>
        /// jsapi_ticket
        /// </summary>
        [JsonPropertyName("ticket")]
        public string Ticket { get; set; }

        /// <summary>
        /// jsapi_ticket接口调用凭证超时时间，单位（秒）,有效期7200秒
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
