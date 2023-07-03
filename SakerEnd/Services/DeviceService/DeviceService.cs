using SakerEnd.Model;

namespace SakerEnd.Services.DeviceService
{
    public class DeviceService
    {
        public List<Device> Devices;

        public DeviceService()
        {
            Devices = new();    
        }
        public void RegisterDevice(ConfigurationDto dto)
        {
            var device = new Device(dto.IP, dto.Port);
            Devices.Add(device);
            var config = DeviceMessageBuilder.GetDeviceConfiguration(dto);
            device.Client.BegindoDeviceConfiguration(config, asyncResult =>
            {

            }, null);
        }
    }
}
