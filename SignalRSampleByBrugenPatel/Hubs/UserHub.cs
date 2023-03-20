using Microsoft.AspNetCore.SignalR;

namespace SignalRSampleByBrugenPatel.Hubs
{
    public class UserHub : Hub
    {
        public static int TotalViews { get; set; } = 0;
        public static int TotalUsers { get ; set; } = 0;

        public override Task OnConnectedAsync()
        {
            TotalUsers++;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            TotalUsers--;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnDisconnectedAsync(exception);
        }

        public async Task NewWindowLoaded()
        {
            //  Whenever new tab opens call this method & increase totalViews
            TotalViews++;

            //  Send update to all clients that total views have been updated
            //  Clients is inside the Hub Implementation
            //  updateTotalViews Method located on client side
            await Clients.All.SendAsync("updateTotalViews", TotalViews);
        }
    }
}