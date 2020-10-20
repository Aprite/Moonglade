namespace Moonglade.Wechat.Infrastructure.Cache
{
    public class JsTicketCacheItem
    {
        public string Ticket { get; set; }

        public JsTicketCacheItem(string ticket)
        {
            Ticket = ticket;
        }

        public static string CalculateCacheKey(string appId)
        {
            return "wechat:jsticket:id:" + appId;
        }
    }
}
