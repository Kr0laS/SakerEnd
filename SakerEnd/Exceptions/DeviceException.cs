namespace SakerEnd.Exceptions
{
    [Serializable]
    public class DeviceException : Exception
    {
        public DeviceException(Device device, string message) :
            base($"Exception for device '{device.Name}' ({device.IP}:{device.Port}): {message}")
        {

        }
        public DeviceException(Device device, string msg, Exception innerException) :
            base($"Exception for device '{device.Name}' ({device.IP}:{device.Port}): {msg}", innerException)
        {

        }
    }
}
