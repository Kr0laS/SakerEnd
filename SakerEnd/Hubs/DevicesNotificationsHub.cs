using Microsoft.AspNetCore.SignalR;

namespace SakerEnd.Hubs
{
    public class DevicesNotificationsHub : Hub
    {
        public async Task NotifyOnDeviceStatusReport(Device device, DeviceStatusReport dsr)
        {
             await Clients.All.SendAsync("DeviceStatusReport", device ,dsr);
        }
    }
}
