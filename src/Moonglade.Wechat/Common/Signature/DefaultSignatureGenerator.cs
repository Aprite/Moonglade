using System.Security.Cryptography;
using System.Text;

namespace Moonglade.Wechat.Common.Signature
{
    public class DefaultSignatureGenerator : ISignatureGenerator
    {
        public string Generate(WeChatParameters parameters, HashAlgorithm hashAlgorithm, string apiKey = null)
        {
            var signStr = $"{parameters.GetWaitForSignatureStr()}{(apiKey != null ? $"&key={apiKey}" : "")}";

            var signBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(signStr));

            var sb = new StringBuilder();
            foreach (var @byte in signBytes)
            {
                sb.Append($"{@byte:x2}");
            }

            return sb.ToString().ToUpper();
        }
    }
}
