using Moonglade.Data.Entities;
using Moonglade.FriendLink;

namespace Moonglade.Web.ViewComponents;

public class FriendLinkViewComponent : ViewComponent
{
    private readonly ILogger<FriendLinkViewComponent> _logger;
    private readonly IMediator _mediator;

    public FriendLinkViewComponent(ILogger<FriendLinkViewComponent> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        try
        {
            var links = await _mediator.Send(new GetAllLinksQuery());
            return View(links ?? new List<FriendLinkEntity>());
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error Reading FriendLink.");
            return Content("ERROR");
        }
    }
}