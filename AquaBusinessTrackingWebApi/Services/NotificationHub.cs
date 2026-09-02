using Microsoft.AspNetCore.SignalR;

namespace AquaBusinessTrackingWebApi.Services
{
    public class NotificationHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var user = Context.UserIdentifier;
            if (user != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"user-{user}");
            }
            await base.OnConnectedAsync();
        }
    }
}
