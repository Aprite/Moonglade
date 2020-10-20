using System;
using System.Text.Json.Serialization;

namespace Moonglade.Wechat
{
    [Serializable]
    public class WeChatJsonResult : BaseJsonResult
    {
        [JsonPropertyName("errcode")]
        public WeChatReturnCode ErrorCode { get; set; } = WeChatReturnCode.Ok;

        /// <summary>
        /// 返回消息代码数字（同errcode枚举值）
        /// </summary>
        public override int ErrorCodeValue { get { return (int)ErrorCode; } }

        public WeChatJsonResult() { }

        public override string ToString()
        {
            return $"WeChatJsonResult：{{errcode:'{ErrorCodeValue}',errcode_name:'{ErrorCode}',errmsg:'{ErrorMessage}'}}";
        }
    }
}
