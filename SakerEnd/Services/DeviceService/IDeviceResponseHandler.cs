namespace SakerEnd.Services.DeviceService;

public interface IDeviceResponseHandler
{
    void HandleDeviceConfiguration(doDeviceConfigurationRequest request);
    void HandleDeviceStatusReport(doDeviceStatusReportRequest request);
}