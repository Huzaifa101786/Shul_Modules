using Microsoft.AspNetCore.SignalR;

namespace Shul_Modules.Services
{
    public class BlastsHub : Hub
    {
        public async Task SendMessageToAll(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
