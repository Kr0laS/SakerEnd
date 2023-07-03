namespace SakerEnd
{
    public class DeviceMessageBuilder
    {
        public static DeviceConfiguration GetDeviceConfiguration(ConfigurationDto dto)
        {
            return new DeviceConfiguration
            {
                RequestorIdentification = "Saker",
                //NotificationServiceIPAddress = dto.IP,
                //NotificationServicePort = dto.Port,
                NotificationServiceIPAddress = "127.0.0.1",
                NotificationServicePort = "13001",
                MessageType = MessageType.Request,
                ProtocolVersion = ProtocolVersionType.Item013,
                MessageTypeSpecified = true
            };
        }
        public static DeviceSubscriptionConfiguration GetDeviceSubscriptionConfiguration(DeviceIdentificationType devId)
        {
            DeviceSubscriptionConfiguration devSub = new DeviceSubscriptionConfiguration();

            SubscriptionTypeType[] subArr = new SubscriptionTypeType[3];
            subArr[0] = SubscriptionTypeType.TechnicalStatus;
            subArr[1] = SubscriptionTypeType.Configuration;
            subArr[2] = SubscriptionTypeType.OperationalIndication;

            devSub.SubscriptionType = subArr;

            devSub.DeviceIdentification = devId;
            devSub.MessageType = MessageType.Request;
            devSub.ProtocolVersion = ProtocolVersionType.Undefined;
            devSub.RequestorIdentification = "marSplunk";

            return devSub;
        }
    }
}
