namespace SakerEnd.Services.DeviceService;

public interface IDeviceService
{
    void InvokeConfigCompleted(DeviceConfiguration request, int index);
    void InvokeStatusCompleted(DeviceStatusReport request, int index);
    Task<DeviceConfiguration> Sendconfiguration(ConfigurationDto dto);
    Task<DeviceStatusReport> SendSubscription(ConfigurationDto dto);
}