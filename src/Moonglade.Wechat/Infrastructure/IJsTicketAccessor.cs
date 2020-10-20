using System.Threading.Tasks;

namespace Moonglade.Wechat.Infrastructure
{
    public interface IJsTicketAccessor
    {
        Task<string> GetTicketAsync();
    }
}
