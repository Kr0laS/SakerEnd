using CoreWCF.IdentityModel.Protocols.WSTrust;
using SakerEnd.Services;

namespace SakerEnd
{
    public class MarsImplamentation : SNSR_STDSOAPPort
    {
        #region - - - DI - - -  
        private readonly IDeviceResponseHandler _responseHandler;

        public MarsImplamentation(DeviceService deviceService, IDeviceResponseHandler responseHandler)
        {
            _responseHandler = responseHandler;
        }
        #endregion


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
            _responseHandler.HandleDeviceConfiguration(request);

            return new();
        }

        public doCommandMessageResponse doDeviceIndicationReport(doDeviceIndicationReportRequest request)
        {
            throw new NotImplementedException();
        }

        public doCommandMessageResponse doDeviceStatusReport(doDeviceStatusReportRequest request)
        {
            _responseHandler.HandleDeviceStatusReport(request);
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
    public delegate void StatusCompleted(DeviceStatusReport status, int index);
    public delegate void ConfigCompleted(DeviceConfiguration configuration,int index);
}
