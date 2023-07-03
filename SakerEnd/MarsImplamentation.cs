using CoreWCF.IdentityModel.Protocols.WSTrust;
using SakerEnd.Services.DeviceService;

namespace SakerEnd
{
    public class MarsImplamentation : SNSR_STDSOAPPort
    {
        private DeviceService _deviceService;
        public MarsImplamentation(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        public IAsyncResult BegindoCommandMessage(doCommandMessageRequest request, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BegindoDeviceConfiguration(doDeviceConfigurationRequest request, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BegindoDeviceIndicationReport(doDeviceIndicationReportRequest request, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BegindoDeviceStatusReport(doDeviceStatusReportRequest request, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BegindoDeviceSubscriptionConfiguration(doDeviceSubscriptionConfigurationRequest request, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public doCommandMessageResponse doCommandMessage(doCommandMessageRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public doDeviceConfigurationResponse doDeviceConfiguration(doDeviceConfigurationRequest request)
        {
            try
            {
                var deviceIndex = _deviceService.Devices.FindIndex(t =>
                t.IP == request.DeviceConfiguration.NotificationServiceIPAddress &&
                t.Port == request.DeviceConfiguration.NotificationServicePort);

                if (deviceIndex == -1) throw new Exception("doDeviceConfiguration error");
                
                _deviceService.Devices[deviceIndex].Configuration = request.DeviceConfiguration;

                var sub = DeviceMessageBuilder.GetDeviceSubscriptionConfiguration(request.DeviceConfiguration.DeviceIdentification);

                _deviceService.Devices[deviceIndex].Client.BegindoDeviceSubscriptionConfiguration(sub ,null ,null );

            }
            catch (Exception)
            {

                throw;
            }
            return new();
        }

        public doCommandMessageResponse doDeviceIndicationReport(doDeviceIndicationReportRequest request)
        {
            throw new NotImplementedException();
        }

        public doCommandMessageResponse doDeviceStatusReport(doDeviceStatusReportRequest request)
        {
            
            var index = _deviceService.Devices.FindIndex(t =>
            t.Configuration.DeviceIdentification.DeviceName == request.DeviceStatusReport.DeviceIdentification.DeviceName);
            
            // need to find a way to send back a response to shoam

            return new();
        }

        public doDeviceSubscriptionConfigurationResponse doDeviceSubscriptionConfiguration(doDeviceSubscriptionConfigurationRequest request)
        {
            throw new NotImplementedException();
        }

        public doCommandMessageResponse EnddoCommandMessage(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public doDeviceConfigurationResponse EnddoDeviceConfiguration(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public doCommandMessageResponse EnddoDeviceIndicationReport(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public doCommandMessageResponse EnddoDeviceStatusReport(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public doDeviceSubscriptionConfigurationResponse EnddoDeviceSubscriptionConfiguration(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
        
    }
    public delegate void ConfigurationCompleted(DeviceStatusReport status);
}
