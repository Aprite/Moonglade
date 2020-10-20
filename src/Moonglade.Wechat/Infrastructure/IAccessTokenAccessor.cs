using System.Threading.Tasks;

namespace Moonglade.Wechat.Infrastructure
{
    public interface IAccessTokenAccessor
    {
        Task<string> GetAccessTokenAsync();
    }
}
