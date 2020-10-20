using System;
using System.Collections.Generic;
using System.Text;

namespace Moonglade.Wechat
{
    public enum WeChatReturnCode : int
    {
        /// <summary>
        /// 系统繁忙，此时请开发者稍候再试
        /// </summary>
        Error = -1,
        /// <summary>
        /// 请求成功
        /// </summary>
        Ok = 0,
        /// <summary>
        /// AppSecret错误或者AppSecret不属于这个公众号，请开发者确认AppSecret的正确性
        /// </summary>
        InvalidAppSecret = 40001,
        /// <summary>
        /// 请确保grant_type字段值为client_credential
        /// </summary>
        InvalidGrantType = 40002,
        InvalidOpenid = 40003,
        InvalidCode = 40029,
        /// <summary>
        /// 调用接口的IP地址不在白名单中，请在接口IP白名单中进行设置。（小程序及小游戏调用不要求IP地址在白名单内。）
        /// </summary>
        InvalidIp = 40164,
        /// <summary>
        /// 此IP调用需要管理员确认,请联系管理员
        /// </summary>
        InvalidIpWithAdmin = 89503,
        /// <summary>
        /// 此IP正在等待管理员确认,请联系管理员
        /// </summary>
        InvalidIpWaitWithAdmin = 89501,
        /// <summary>
        /// 24小时内该IP被管理员拒绝调用两次，24小时内不可再使用该IP调用
        /// </summary>
        InvalidIpWithRefuse24 = 89506,
        /// <summary>
        /// 1小时内该IP被管理员拒绝调用一次，1小时内不可再使用该IP调用
        /// </summary>
        InvalidIpWithRefuse1 = 89507,
    }
}
