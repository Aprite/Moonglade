using System.Threading.Tasks;

namespace Moonglade.Wechat
{
    public interface IJsSdkService
    {
        Task<JsSdkConfigParameters> GetJsSdkUiPackageAsync(string url);
    }
}
