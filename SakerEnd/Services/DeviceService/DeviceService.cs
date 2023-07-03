namespace SakerEnd.Services.DeviceService
{
    public class DeviceService : IDeviceService
    {
        List<Device> _devices;

        public DeviceService()
        {
            _devices = new();    
        }
        public void RegisterDevice(ConfigurationDto dto)
        {
            var device = new Device(dto.IP, dto.Port);
            var config = DeviceMessageBuilder.GetDeviceConfiguration(dto);
            device.Client.BegindoDeviceConfiguration(config, asyncResult =>
            {

            }, null);
        }
    }
}
