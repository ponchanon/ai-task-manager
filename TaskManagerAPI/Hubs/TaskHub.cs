using Microsoft.AspNetCore.SignalR;

namespace TaskManagerAPI.Hubs
{
    public class TaskHub : Hub
    {
        public async Task NotifyTaskUpdate(string message)
        {
            await Clients.All.SendAsync("TaskUpdated", message);
        }
    }
}
