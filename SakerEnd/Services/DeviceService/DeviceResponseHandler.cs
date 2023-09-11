namespace SakerEnd.Services.DeviceService;

public class DeviceResponseHandler : IDeviceResponseHandler
{
    private readonly DeviceService _deviceService;

    public DeviceResponseHandler(DeviceService deviceService)
    {
        _deviceService = deviceService;
    }

    public void HandleDeviceConfiguration(doDeviceConfigurationRequest request)
    {
        var deviceIndex = _deviceService.Devices.FindIndex(t =>
        t.IP == request.DeviceConfiguration.NotificationServiceIPAddress &&
        t.Port == request.DeviceConfiguration.NotificationServicePort);

        if (deviceIndex == -1) throw new Exception("doDeviceConfiguration error");

        _deviceService.Devices[deviceIndex].Configuration = request.DeviceConfiguration;
        _deviceService.Devices[deviceIndex].IdentificationType = request.DeviceConfiguration.DeviceIdentification;
        _deviceService.InvokeConfigCompleted(request.DeviceConfiguration, deviceIndex);

    }

    public void HandleDeviceStatusReport(doDeviceStatusReportRequest request)
    {

        var index = _deviceService.Devices.FindIndex(t =>
        t.Configuration.DeviceIdentification.DeviceName == request.DeviceStatusReport.DeviceIdentification.DeviceName);

        _deviceService.Devices[index].DeviceStatusReport = request.DeviceStatusReport;
        _deviceService.InvokeStatusCompleted(request.DeviceStatusReport, index);
    }
}
