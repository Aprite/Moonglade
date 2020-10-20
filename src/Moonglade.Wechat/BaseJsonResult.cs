using System;
using System.Text.Json.Serialization;

namespace Moonglade.Wechat
{
    [Serializable]
    public abstract class BaseJsonResult
    {
        /// <summary>
        /// 返回结果信息
        /// </summary>
        [JsonPropertyName("errmsg")]
        public virtual string ErrorMessage { get; set; }

        /// <summary>
        /// errcode的
        /// </summary>
        public abstract int ErrorCodeValue { get; }
    }
}
