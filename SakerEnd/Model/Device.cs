using System.ServiceModel;

namespace SakerEnd.Model
{
    public class Device
    {
        public Device(string ip, string port)
        {
            IP = ip;
            Port = port;
            Client = new SNSR_STDSOAPPortClient(new BasicHttpBinding(),
                new EndpointAddress($"http://{IP}:{Port}/SNSR_STD-SOAP"));
        }

        public DeviceConfiguration Configuration { get; set; }

        public string Name { get; set; } = string.Empty;

        public string IP { get; private set; }

        public string Port { get; private set; }

        public SNSR_STDSOAPPortClient Client { get; private set; }

        public DeviceIdentificationType IdentificationType { get; set; }
    }
}
