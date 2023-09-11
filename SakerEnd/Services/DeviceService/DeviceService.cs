using SakerEnd.Exceptions;
using WCFSensorsLib;

namespace SakerEnd.Services.DeviceService;

public class DeviceService : IDeviceService
{
    private const int TIMEOUT_DURATION = 10;

    private event StatusCompleted DeviceStatusCompleted;
    private event ConfigCompleted DeviceConfigCompleted;

    public void InvokeConfigCompleted(DeviceConfiguration request, int index)
    {
        DeviceConfigCompleted?.Invoke(request, index);
    }

    public void InvokeStatusCompleted(DeviceStatusReport request, int index)
    {
        DeviceStatusCompleted?.Invoke(request, index);
    }

    public List<Device> Devices;
    //private DevicesNotificationsHub _signalR;

    public DeviceService()//DevicesNotificationsHub signalR)
    {
        //_signalR = signalR;
        Devices = new();
    }

    /// <summary>
    /// sends configuration...
    /// </summary>
    public async Task<DeviceConfiguration> Sendconfiguration(ConfigurationDto dto)
    {
        var device = new Device(dto.IP, dto.Port);
        Devices.Add(device);

        var config = DeviceMessageBuilder.GetDeviceConfiguration(dto);

        var responseCompletionSource = new TaskCompletionSource<DeviceConfiguration>();

        DeviceConfigCompleted += (report, index) =>
        {
            if (responseCompletionSource.Task.IsCompleted) return;
            responseCompletionSource.SetResult(report);
        };

        device.Client.BegindoDeviceConfiguration(config, null, null);

        var timeoutTask = Task.Delay(TimeSpan.FromSeconds(TIMEOUT_DURATION));
        var completedTask = await Task.WhenAny(responseCompletionSource.Task, timeoutTask);

        if (completedTask == timeoutTask)
            throw new DeviceException(device, "Time Limit Exceeded");

        return await responseCompletionSource.Task;

    }

    public async Task<DeviceStatusReport> SendSubscription(ConfigurationDto dto)
    {
        var device = Devices.Find(x => x.IP == dto.IP && x.Port == dto.Port);

        var sub = DeviceMessageBuilder.GetDeviceSubscriptionConfiguration(device.IdentificationType);

        var responseCompletionSource = new TaskCompletionSource<DeviceStatusReport>();

        DeviceStatusCompleted += (report, index) =>
        {
            if (responseCompletionSource.Task.IsCompleted)
            {
                return;
                //await _signalR.NotifyOnDeviceStatusReport(Devices[index],report);
            }
            responseCompletionSource.SetResult(report);
        };

        device.Client.BegindoDeviceSubscriptionConfiguration(sub, null, null);

        var timeoutTask = Task.Delay(TimeSpan.FromSeconds(TIMEOUT_DURATION));
        var completedTask = await Task.WhenAny(responseCompletionSource.Task, timeoutTask);

        if (completedTask == timeoutTask)
            throw new DeviceException(device, "Time Limit Exceeded");

        return await responseCompletionSource.Task;


    }

    internal Device? GetDevice(DeviceDto dto)
    {
        var deviceIndex = Devices.FindIndex(t =>
                t.IP == dto.IP &&
                t.Port == dto.Port);
        return deviceIndex == -1 ? null : Devices[deviceIndex];
    }
}
